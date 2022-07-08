using KursyWalutLibrary;
using KursyWalutLibrary.Enum;
using KursyWalutLibrary.Models;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace KursyWalutWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Result Data { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() => Main(new string[] { "EUR", "2018-12-20", "2018-12-31" })).Wait();
            BuyAverage.Text = Data.averageRate.Buy.ToString();
            SellAverage.Text = Data.averageRate.Sell.ToString();

            BuyMinimum.Text = Data.minimumRate.Buy.ToString();
            SellMinimum.Text = Data.minimumRate.Sell.ToString();

            BuyMaximum.Text = Data.maximumRate.Buy.ToString();
            SellMaximum.Text = Data.maximumRate.Sell.ToString();

            BuyDeviation.Text = Data.standardDeviation.Buy.ToString();
            SellDeviation.Text = Data.standardDeviation.Sell.ToString();

            HighestDiff.Text = Data.highestDifference.Difference.ToString();
            HighestDate.Text = Data.highestDifference.PublicationDate.ToString();
        }

        public async static Task Main(string[] args)
        {
            KursWalutLib kursWalut = new KursWalutLib();

            if (args.Length != 3)
                return;

            string currency = args[0];
            string dataFrom = args[1];
            string dataTo = args[2];

            if (!IsValid(currency, dataFrom, dataTo, out CurrencyEnum currencyValid))
                return;

            Data = await kursWalut.GetXMLDocument(currencyValid, dataFrom, dataTo);

        }

        public static bool IsValid(
        string currency,
        string dateFrom,
        string dateTo,
        out CurrencyEnum currencyValid)
        {
            if (!Enum.TryParse<CurrencyEnum>(currency, out currencyValid))
                return false;

            if (!DateTime.TryParse(dateFrom, out DateTime dateFromValid))
                return false;

            if (!DateTime.TryParse(dateTo, out DateTime dateToValid))
                return false;

            if (dateFromValid.Date > DateTime.Now.Date || dateFromValid.Date < DateTime.Parse("2002-01-01").Date)
                return false;

            if (dateToValid.Date > DateTime.Now.Date || dateToValid.Date < DateTime.Parse("2002-01-01").Date)
                return false;

            if (dateFromValid.Date > dateToValid.Date)
                return false;

            return true;
        }
    }
}
