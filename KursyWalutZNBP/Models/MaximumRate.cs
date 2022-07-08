namespace KursyWalutLibrary.Models
{
    public class MaximumRate : IBuySell<decimal>
    {
        public MaximumRate(decimal buy, decimal sell)
        {
            Buy = buy;
            Sell = sell;
        }

        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
    }
}
