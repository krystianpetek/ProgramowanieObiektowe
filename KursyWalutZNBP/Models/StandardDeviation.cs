namespace KursyWalutLibrary.Models
{
    public class StandardDeviation : IBuySell<double>
    {
        public StandardDeviation(double buy, double sell)
        {
            Buy = buy;
            Sell = sell;
        }

        public double Buy { get; set; }
        public double Sell { get; set; }
    }
}
