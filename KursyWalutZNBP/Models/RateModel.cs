namespace KursyWalutLibrary.Models
{
    public class RateModel : IRateModel
    {
        public RateModel(string fileName, DateTime publicationDate, decimal buyRate, decimal sellRate)
        {
            FileName = fileName;
            PublicationDate = publicationDate;
            BuyRate = buyRate;
            SellRate = sellRate;
        }

        public string FileName { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
    }
}
