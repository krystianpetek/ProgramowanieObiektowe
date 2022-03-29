using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie2.Device;
using Zadanie2.Document;

namespace Zadanie2UnitTests
{
    [TestClass]
    public class UnitTestMultiFunctionalDevice
    {
        /// <summary>
        /// Weryfikacja czy urządzenie jest wyłączone 
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_GetState_StateOff()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOff();
            Assert.AreEqual(IDevice.State.OFF, multiFunctionalDevice.GetState());
        }

        /// <summary>
        /// Weryfikacja czy urządzenie jest włączone
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_GetState_StateOn()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();
            Assert.AreEqual(IDevice.State.ON, multiFunctionalDevice.GetState());
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Print', gdy uruchomione jest urządzenie, w napicie NIE pojawia się słowo 'Print'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_Print_DeviceOff()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multiFunctionalDevice.Print(in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
        
        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Print', gdy uruchomione jest urządzenie, w napicie pojawia się słowo 'Print'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_Print_DeviceOn()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multiFunctionalDevice.Print(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print:"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', gdy uruchomione jest urządzenie, w napicie NIE pojawia się słowo 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_Scan_DeviceOff()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document1;
                multiFunctionalDevice.Scan(out document1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', gdy uruchomione jest urządzenie, w napicie pojawia się słowo 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_Scan_DeviceOn()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multiFunctionalDevice.Scan(out doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy wywołanie metody `Scan` z parametrem określającym format dokumentu zawiera odpowiednie rozszerzenie ( `.jpg`, `.txt`, `.pdf` )
        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', z parametrem określającym format dokumentu zawiera odpowiednie rozszerzenie np.
        /// .jpg // .txt // .pdf, gdy uruchomione jest urządzenie.
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_Scan_FormatTypeDocument()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                multiFunctionalDevice.Scan(out document, IDocument.FormatType.TXT);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

                multiFunctionalDevice.Scan(out document, IDocument.FormatType.JPG);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

                multiFunctionalDevice.Scan(out document, IDocument.FormatType.PDF);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'ScanAndPrint', gdy uruchomione jest urządzenie, w napicie pojawiają się słowa 'Print' oraz 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultiFunctionalDevice_ScanAndPrint_DeviceOn()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multiFunctionalDevice.ScanAndPrint();
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywołaniu metody `ScanAndPrint` i wyłączonym urządzeniu wielofunkcyjnym w napisie NIE pojawia się słowo `Print`
        // ani słowo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultiFunctionalDevice_ScanAndPrint_DeviceOff()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOff();
            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multiFunctionalDevice.ScanAndPrint();
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja ilości wydruku plików przez urządzenie wielofunkcyjne
        [TestMethod]
        public void MultiFunctionalDevice_PrintCounter()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            multiFunctionalDevice.Print(in doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            multiFunctionalDevice.Print(in doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            multiFunctionalDevice.Print(in doc3);

            multiFunctionalDevice.PowerOff();
            multiFunctionalDevice.Print(in doc3);
            multiFunctionalDevice.Scan(out doc1);
            multiFunctionalDevice.PowerOn();

            multiFunctionalDevice.ScanAndPrint();
            multiFunctionalDevice.ScanAndPrint();

            // 5 wydrukó, gdy urządzenie włączone
            Assert.AreEqual(5, multiFunctionalDevice.PrintCounter);
        }
        
        [TestMethod]
        public void MultiFunctionalDevice_ScanCounter()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();

            IDocument doc1;
            multiFunctionalDevice.Scan(out doc1);
            IDocument doc2;
            multiFunctionalDevice.Scan(out doc2);

            IDocument doc3 = new ImageDocument("aaa.jpg");
            multiFunctionalDevice.Print(in doc3);

            multiFunctionalDevice.PowerOff();
            multiFunctionalDevice.Print(in doc3);
            multiFunctionalDevice.Scan(out doc1);
            multiFunctionalDevice.PowerOn();

            multiFunctionalDevice.ScanAndPrint();
            multiFunctionalDevice.ScanAndPrint();

            // 4 skany, gdy urzadzenie właczone
            Assert.AreEqual(4, multiFunctionalDevice.ScanCounter);
        }

        // licznik włączeń
        [TestMethod]
        public void MultiFunctionalDevice_PowerOnCounter()
        {
            var multiFunctionalDevice = new MultiFunctionalDevice();
            multiFunctionalDevice.PowerOn();
            multiFunctionalDevice.PowerOn();
            multiFunctionalDevice.PowerOn();

            IDocument document1;
            multiFunctionalDevice.Scan(out document1);
            IDocument document2;
            multiFunctionalDevice.Scan(out document2);

            multiFunctionalDevice.PowerOff();
            multiFunctionalDevice.PowerOff();
            multiFunctionalDevice.PowerOff();
            multiFunctionalDevice.PowerOn();

            IDocument document3 = new ImageDocument("aaa.jpg");
            multiFunctionalDevice.Print(in document3);

            multiFunctionalDevice.PowerOff();
            multiFunctionalDevice.Print(in document3);
            multiFunctionalDevice.Scan(out document1);
            multiFunctionalDevice.PowerOn();

            multiFunctionalDevice.ScanAndPrint();
            multiFunctionalDevice.ScanAndPrint();

            // 3 włączenia
            Assert.AreEqual(3, multiFunctionalDevice.Counter);
        }
    }
}