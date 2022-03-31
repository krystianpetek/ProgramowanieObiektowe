using Zadanie5.Document;

namespace Zadanie5.Device
{
    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od null</param>
        public void Print(in IDocument document)
        {
            if (GetState() == State.ON)
            {
                Counter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
            }
        }
    }
}