using Zadanie2.Device;
using Zadanie2.Document;

var xerox = new MultiFunctionalDevice();
xerox.PowerOn();
IDocument doc1 = new PDFDocument("aaa.pdf");
xerox.Print(in doc1);

IDocument doc1Fax;
xerox.ReceiveFax(out doc1Fax);

IDocument doc2;
xerox.Scan(out doc2);

xerox.SendFax("123123123");

xerox.ScanAndPrint();
System.Console.WriteLine(xerox.Counter);
System.Console.WriteLine(xerox.PrintCounter);
System.Console.WriteLine(xerox.ScanCounter);