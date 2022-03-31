using Zadanie4.Device;
using Zadanie4.Document;

Copier xerox = new Copier();
IPrinter printer = xerox;
IScanner scanner = xerox;

xerox.PowerOnCopier();

IDocument doc1 = new PDFDocument("aaa.pdf");
printer.Print(in doc1);

IDocument doc2;
scanner.Scan(out doc2);

xerox.ScanAndPrint();
Console.WriteLine(xerox.Counter);
Console.WriteLine(printer.Counter);
Console.WriteLine(scanner.Counter);