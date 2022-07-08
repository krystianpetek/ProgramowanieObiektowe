namespace KursyWalutLibrary.Models
{
    public interface IRateModel
    {
        decimal BuyRate { get; set; }
        string FileName { get; set; }
        DateTime PublicationDate { get; set; }
        decimal SellRate { get; set; }
    }
}