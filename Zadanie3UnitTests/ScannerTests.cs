using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie3.Device;
using Zadanie3.Document;

namespace Zadanie3UnitTests
{
    [TestClass]
    public class ScannerTests
    {
        /// <summary>
        /// Weryfikacja czy urządzenie jest wyłączone
        /// </summary>
        [TestMethod]
        public void Scanner_GetState_StateOff()
        {
            var scanner = new Scanner();
            scanner.PowerOff();
            Assert.AreEqual(IDevice.State.OFF, scanner.GetState());
        }

        /// <summary>
        /// Weryfikacja czy urządzenie jest włączone
        /// </summary>
        [TestMethod]
        public void Scanner_GetState_StateOn()
        {
            var scanner = new Scanner();
            scanner.PowerOn();
            Assert.AreEqual(IDevice.State.ON, scanner.GetState());
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', gdy urządzenie NIE jest uruchomione, w napisie NIE pojawia się słowo 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void Scanner_Scan_DeviceOff()
        {
            var scanner = new Scanner();
            scanner.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document1;
                scanner.Scan(out document1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', gdy uruchomione jest urządzenie, w napicie pojawia się słowo 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void Scanner_Scan_DeviceOn()
        {
            var scanner = new Scanner();
            scanner.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                scanner.Scan(out doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', z parametrem określającym format dokumentu zawiera odpowiednie rozszerzenie np.
        /// .jpg // .txt // .pdf, gdy uruchomione jest urządzenie.
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void Scanner_Scan_FormatTypeDocument()
        {
            var scanner = new Scanner();
            scanner.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                scanner.Scan(out document, IDocument.FormatType.TXT);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

                scanner.Scan(out document, IDocument.FormatType.JPG);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

                scanner.Scan(out document, IDocument.FormatType.PDF);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja ilości skanów plików przez urządzenie wielofunkcyjne
        /// </summary>
        [TestMethod]
        public void Scanner_ScanCounter()
        {
            var scanner = new Scanner();
            scanner.PowerOn();

            IDocument doc1;
            scanner.Scan(out doc1);
            IDocument doc2;
            scanner.Scan(out doc2);

            IDocument doc3 = new ImageDocument("aaa.jpg");

            scanner.PowerOff();
            scanner.Scan(out doc1);
            scanner.PowerOn();
            scanner.Scan(out doc1);
            scanner.Scan(out doc1);

            // 4 skany, gdy urzadzenie właczone
            Assert.AreEqual(4, scanner.ScanCounter);
        }

        /// <summary>
        /// Weryfikacja ilości uruchomień urządzenia wielofunkcyjnego
        /// </summary>
        [TestMethod]
        public void Scanner_PowerOnCounter()
        {
            var scanner = new Scanner();
            scanner.PowerOn();
            scanner.PowerOn();
            scanner.PowerOn();

            IDocument document1;
            scanner.Scan(out document1);
            IDocument document2;
            scanner.Scan(out document2);

            scanner.PowerOff();
            scanner.PowerOff();
            scanner.PowerOff();
            scanner.PowerOn();

            scanner.PowerOff();
            scanner.Scan(out document1);
            scanner.PowerOn();

            // 3 włączenia
            Assert.AreEqual(3, scanner.Counter);
        }
    }
}