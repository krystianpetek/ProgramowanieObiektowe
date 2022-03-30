using Zadanie4.Device;
using Zadanie4.Document;

Copier xerox = new Copier();
IDocument doc1 = new PDFDocument("aaa.pdf");
xerox.Print(doc1);
xerox.PowerOn();
xerox.Print(in doc1);

IDocument doc2;
xerox.Scan(out doc2);

xerox.ScanAndPrint();
System.Console.WriteLine(xerox.Counter);
System.Console.WriteLine(xerox.PrintCounter);
System.Console.WriteLine(xerox.ScanCounter);