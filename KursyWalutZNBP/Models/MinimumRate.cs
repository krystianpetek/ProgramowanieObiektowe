namespace KursyWalutLibrary.Models
{
    public class MinimumRate : IBuySell<decimal>
    {
        public MinimumRate(decimal buy, decimal sell)
        {
            Buy = buy;
            Sell = sell;
        }

        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
    }
}
