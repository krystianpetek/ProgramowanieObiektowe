namespace KursyWalutLibrary.Enum
{
    public class Currency
    {
        const string USD = "dolar amerykański";
        const string EUR = "euro";
        const string CHF = "frank szwajcarski";
        const string GBP = "funt szterling";
        public readonly Dictionary<CurrencyEnum, string> currencies;

        public Currency()
        {
            currencies = new Dictionary<CurrencyEnum, string>();
            currencies[CurrencyEnum.EUR] = EUR;
            currencies[CurrencyEnum.USD] = USD;
            currencies[CurrencyEnum.CHF] = CHF;
            currencies[CurrencyEnum.GBP] = GBP;
        }
    }

    public enum CurrencyEnum
    {
        USD, EUR, CHF, GBP
    }
}
