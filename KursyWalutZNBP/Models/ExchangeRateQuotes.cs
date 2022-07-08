using KursyWalutLibrary.Enum;

namespace KursyWalutLibrary.Models
{
    public class ExchangeRateQuotes : IExchangeRateQuotes
    {
        public ExchangeRateQuotes(DateTime dateFrom, DateTime dateTo, string currencyName, CurrencyEnum currencyCode, List<IRateModel> exchangeRates)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            CurrencyName = currencyName;
            CurrencyCode = currencyCode;
            ExchangeRates = exchangeRates;
        }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CurrencyName { get; set; }
        public CurrencyEnum CurrencyCode { get; set; }
        public IList<IRateModel> ExchangeRates { get; set; }
    }
}
