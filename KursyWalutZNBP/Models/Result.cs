namespace KursyWalutLibrary.Models
{
    public class Result
    {
        public Result(AverageRate averageRate, StandardDeviation standardDeviation, MinimumRate minimumRate, MaximumRate maximumRate, HighestDifference highestDifference)
        {
            this.averageRate = averageRate;
            this.standardDeviation = standardDeviation;
            this.minimumRate = minimumRate;
            this.maximumRate = maximumRate;
            this.highestDifference = highestDifference;
        }

        public AverageRate averageRate { get; set; }
        public StandardDeviation standardDeviation { get; set; }
        public MinimumRate minimumRate { get; set; }
        public MaximumRate maximumRate { get; set; }
        public HighestDifference highestDifference { get; set; }

        public override string ToString()
        {
            return $"\t\t\tBuy:\t\t\t\t\tSell:\n" +
                $"Average rate:\t\t{averageRate.Buy}\t\t{averageRate.Sell}\n" +
                $"Standard deviation:\t{standardDeviation.Buy}\t\t\t{standardDeviation.Sell}\n" +
                $"Minimum rate:\t\t{minimumRate.Buy}\t\t\t\t\t{minimumRate.Sell}\n" +
                $"Maximum rate:\t\t{maximumRate.Buy}\t\t\t\t\t{maximumRate.Sell}\n\n" +
                $"Highest difference: {highestDifference.Difference}\n" +
                $"Publication date: {highestDifference.PublicationDate}";
        }
    }
}
