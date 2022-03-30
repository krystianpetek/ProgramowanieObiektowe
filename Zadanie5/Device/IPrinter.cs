using Zadanie4.Document;

namespace Zadanie4.Device
{
    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od null</param>
        public void Print(in IDocument document);

    }
}