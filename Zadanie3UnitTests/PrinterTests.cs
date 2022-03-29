using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie3.Device;
using Zadanie3.Document;

namespace Zadanie3UnitTests
{
    [TestClass]
    public class PrinterTests
    {
        /// <summary>
        /// Weryfikacja czy urządzenie jest wyłączone
        /// </summary>
        [TestMethod]
        public void Printer_GetState_StateOff()
        {
            var printer = new Printer();
            printer.PowerOff();
            Assert.AreEqual(IDevice.State.OFF, printer.GetState());
        }

        /// <summary>
        /// Weryfikacja czy urządzenie jest włączone
        /// </summary>
        [TestMethod]
        public void Printer_GetState_StateOn()
        {
            var printer = new Printer();
            printer.PowerOn();
            Assert.AreEqual(IDevice.State.ON, printer.GetState());
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Print', gdy urządzenie NIE jest uruchomione, w napisie NIE pojawia się słowo 'Print'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void Printer_Print_DeviceOff()
        {
            var printer = new Printer();
            printer.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                printer.Print(in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Print', gdy uruchomione jest urządzenie, w napicie pojawia się słowo 'Print'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void Printer_Print_DeviceOn()
        {
            var printer = new Printer();
            printer.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                printer.Print(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print:"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja ilości wydruku plików przez urządzenie wielofunkcyjne
        /// </summary>
        [TestMethod]
        public void Printer_PrintCounter()
        {
            var printer = new Printer();
            printer.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            printer.Print(in doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            printer.Print(in doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            printer.Print(in doc3);

            printer.PowerOff();
            printer.Print(in doc3);
            printer.PowerOn();

            printer.Print(in doc3);
            printer.Print(in doc3);

            // 5 wydruków, gdy urządzenie włączone
            Assert.AreEqual(5, printer.PrintCounter);
        }

        /// <summary>
        /// Weryfikacja ilości uruchomień urządzenia wielofunkcyjnego
        /// </summary>
        [TestMethod]
        public void Printer_PowerOnCounter()
        {
            var printer = new Printer();
            printer.PowerOn();
            printer.PowerOn();
            printer.PowerOn();

            printer.PowerOff();
            printer.PowerOff();
            printer.PowerOff();
            printer.PowerOn();

            IDocument document3 = new ImageDocument("aaa.jpg");
            printer.Print(in document3);

            printer.PowerOff();
            printer.Print(in document3);
            printer.PowerOn();

            // 3 włączenia
            Assert.AreEqual(3, printer.Counter);
        }
    }
}