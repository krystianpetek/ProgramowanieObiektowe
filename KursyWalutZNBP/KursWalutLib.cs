using KursyWalutLibrary.Enum;
using KursyWalutLibrary.Models;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace KursyWalutLibrary
{
    public class KursWalutLib
    {
        public HttpClient clientHttp = new HttpClient();

        public IFormatProvider formatProvider = new CultureInfo("en-US").DateTimeFormat;
        public async Task<Result> GetXMLDocument(CurrencyEnum currency, string dataFrom, string dataTo)
        {
            var exchangeRateListInHtml = await GetExchangeRateList();

            var exchangeRateQuotes = await FilterCollection(currency, dataFrom, dataTo, exchangeRateListInHtml);

            var averageRate = GetAverageRate(exchangeRateQuotes);
            var standardDeviation = GetStandardDeviation(exchangeRateQuotes);
            var minimumRate = GetMinimumRate(exchangeRateQuotes);
            var maximumRate = GetMaximumRate(exchangeRateQuotes);
            var highestDifference = GetDifference(exchangeRateQuotes);

            return new Result(averageRate, standardDeviation, minimumRate, maximumRate, highestDifference);
        }

        private HighestDifference GetDifference(IExchangeRateQuotes exchangeRateQuotes)
        {
            var result = exchangeRateQuotes.ExchangeRates.Select(x => (difference: x.SellRate - x.BuyRate, publicationDate: x.PublicationDate)).OrderBy(x => x).TakeLast(1).SingleOrDefault();

            return new HighestDifference() { Difference = result.difference, PublicationDate = result.publicationDate };
        }

        private async Task<IEnumerable<string>> GetExchangeRateList()
        {
            var getResponse = await clientHttp.GetAsync($"https://www.nbp.pl/kursy/xml/dir.aspx?tt=C");
            if (!getResponse.IsSuccessStatusCode)
                return null;

            using var streamReader = new StreamReader(await getResponse.Content.ReadAsStreamAsync(), Encoding.GetEncoding("iso-8859-1"));
            string exchangeRateListInHtml = streamReader.ReadToEnd();

            List<string> exchangeRateQuotes = new List<string>();
            var cutFromHtmlLinkTags = exchangeRateListInHtml.Split("<pre")[1].Split("<a href=\"").ToList();

            for (int i = 1; i < cutFromHtmlLinkTags.Count - 1; i++)
                exchangeRateQuotes.Add(cutFromHtmlLinkTags[i].Split("\">")[0]);

            return exchangeRateQuotes;
        }

        private async Task<IExchangeRateQuotes> FilterCollection(CurrencyEnum currency, string dataFrom, string dataTo, IEnumerable<string> exchangeRateQuotes)
        {
            var dataFromValid = dataFrom.Substring(2, 2) + dataFrom.Substring(5, 2) + dataFrom.Substring(8, 2);
            var dataToValid = dataTo.Substring(2, 2) + dataTo.Substring(5, 2) + dataTo.Substring(8, 2);

            var filterDate = exchangeRateQuotes
                .Where(x => int.Parse(x.Substring(x.Length - 10, 6)) >= int.Parse(dataFromValid) && int.Parse(x.Substring(x.Length - 10, 6)) <= int.Parse(dataToValid))
                .Select(a => a)
                .ToList();

            List<IRateModel> rateXMLModel = new();
            foreach (var fileName in filterDate)
            {
                var getResponse = await clientHttp.GetAsync($"https://www.nbp.pl/kursy/xml/{fileName}");
                if (!getResponse.IsSuccessStatusCode)
                    return null;

                using StreamReader streamReader = new(await getResponse.Content.ReadAsStreamAsync(), Encoding.GetEncoding("iso-8859-1"));
                string exchangeRateListInHtml = streamReader.ReadToEnd();

                var root = XDocument.Parse(exchangeRateListInHtml);

                var publicationDate = DateTime.Parse(root.Descendants("data_publikacji").FirstOrDefault()!.Value);
                var parent = root.Descendants("kod_waluty").FirstOrDefault(x => x.Value == currency.ToString())!.Parent;
                var kodWaluty = parent!.Element("kod_waluty")!.Value;
                var buyRate = decimal.Parse(parent.Element("kurs_kupna")!.Value);
                var sellRate = decimal.Parse(parent.Element("kurs_sprzedazy")!.Value);

                rateXMLModel.Add(new RateModel(fileName, publicationDate, buyRate, sellRate));
            }

            return new ExchangeRateQuotes(DateTime.Parse(dataFrom), DateTime.Parse(dataTo), ParseCurrencyName(currency), currency, rateXMLModel);
        }

        private string ParseCurrencyName(CurrencyEnum currency)
        {
            return new Currency().currencies.FirstOrDefault(x => x.Key == currency)!.Value;
        }

        private AverageRate GetAverageRate(IExchangeRateQuotes exchangeRateQuotes)
        {
            var buy = exchangeRateQuotes.ExchangeRates.Average(x => x.BuyRate);
            var sell = exchangeRateQuotes.ExchangeRates.Average(x => x.SellRate);
            return new AverageRate(buy, sell);
        }

        private StandardDeviation GetStandardDeviation(IExchangeRateQuotes exchangeRateQuotes)
        {
            var buy = StandardDeviation(exchangeRateQuotes.ExchangeRates.Select(x => (double)x.BuyRate));
            var sell = StandardDeviation(exchangeRateQuotes.ExchangeRates.Select(x => (double)x.SellRate));

            return new StandardDeviation(buy, sell);
        }

        public double StandardDeviation(IEnumerable<double> values)
        {
            double N = 0;
            double Sx = 0.0;
            double Sxx = 0.0;

            foreach (double x in values)
            {
                N += 1;
                Sx += x;
                Sxx += x * x;
            }

            return N == 0 ? double.NaN : Math.Sqrt((Sxx - Sx * Sx / N) / N);
        }

        private MinimumRate GetMinimumRate(IExchangeRateQuotes exchangeRateQuotes)
        {
            var buy = exchangeRateQuotes.ExchangeRates.Min(x => x.BuyRate);
            var sell = exchangeRateQuotes.ExchangeRates.Min(x => x.SellRate);

            return new MinimumRate(buy, sell);
        }

        private MaximumRate GetMaximumRate(IExchangeRateQuotes exchangeRateQuotes)
        {
            var buy = exchangeRateQuotes.ExchangeRates.Max(x => x.BuyRate);
            var sell = exchangeRateQuotes.ExchangeRates.Max(x => x.SellRate);

            return new MaximumRate(buy, sell);
        }
    }
}