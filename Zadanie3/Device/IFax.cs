using Zadanie3.Document;

namespace Zadanie3.Device
{
    internal interface IFax : IDevice
    {
        /// <summary>
        /// Fax jest wysyłany w momencie, gdy urządzenie jest włączone, w przeciwnym razie nic się nie dzieje
        /// </summary>
        /// <param name="faxNumber">numer faxu na jaki ma być wysłany dokument</param>
        public void SendFax(string faxNumber);

        /// <summary>
        /// Fax jest odbierany tylko w momencie, gdy urządzenie jest włączone, w przeciwnym razie nic się nie dzieje
        /// </summary>
        /// <param name="document">Dokument odebrany faxem</param>
        public void ReceiveFax(out IDocument document);
    }
}