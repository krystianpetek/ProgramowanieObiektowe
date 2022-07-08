namespace KursyWalutLibrary.Models
{
    public class AverageRate : IBuySell<decimal>
    {
        public AverageRate(decimal buy, decimal sell)
        {
            Buy = buy;
            Sell = sell;
        }

        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
    }
}
