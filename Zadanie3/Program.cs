using Zadanie3.Device;
using Zadanie3.Document;

var xerox = new MultidimensionalDevice();
xerox.PowerOn();
IDocument doc1 = new PDFDocument("aaa.pdf");
xerox.Print(in doc1);

xerox.ReceiveFax(out doc1);
xerox.ReceiveFax(out doc1);

IDocument doc2;
xerox.Scan(out doc2);
xerox.SendFax("+48338720020");

xerox.ScanAndPrint();
Console.WriteLine($"Ilość uruchomień urządzenia wielofunkcyjnego: {xerox.Counter}");
Console.WriteLine($"Ilość wydruków z urządzenia wielofunkcyjnego: {xerox.PrintCounter}");
Console.WriteLine($"Ilość skanów z urządzenia wielofunkcyjnego: {xerox.ScanCounter}");
Console.WriteLine($"Ilość wysłanych faxów z urządzenia wielofunkcyjnego: {xerox.SendFaxCounter}");
Console.WriteLine($"Ilość odebranych faxów z urządzenia wielofunkcyjnego: {xerox.ReceiveFaxCounter}");