using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie3.Device;
using Zadanie3.Document;

namespace Zadanie3UnitTests
{
    [TestClass]
    public class MultidimensionalDeviceTests
    {
        /// <summary>
        /// Weryfikacja czy urządzenie jest wyłączone
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_GetState_StateOff()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOff();
            Assert.AreEqual(IDevice.State.OFF, multidimensionalDevice.GetState());
        }

        /// <summary>
        /// Weryfikacja czy urządzenie jest włączone
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_GetState_StateOn()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();
            Assert.AreEqual(IDevice.State.ON, multidimensionalDevice.GetState());
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Print', gdy urządzenie NIE jest uruchomione, w napisie NIE pojawia się słowo 'Print'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_Print_DeviceOff()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multidimensionalDevice.Print(in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Print', gdy uruchomione jest urządzenie, w napicie pojawia się słowo 'Print'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_Print_DeviceOn()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multidimensionalDevice.Print(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print:"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', gdy urządzenie NIE jest uruchomione, w napisie NIE pojawia się słowo 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_Scan_DeviceOff()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document1;
                multidimensionalDevice.Scan(out document1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', gdy uruchomione jest urządzenie, w napicie pojawia się słowo 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_Scan_DeviceOn()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multidimensionalDevice.Scan(out doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'ScanAndPrint', gdy uruchomione jest urządzenie, w napicie pojawiają się słowa 'Print' oraz 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_ScanAndPrint_DeviceOn()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multidimensionalDevice.ScanAndPrint();
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'ScanAndPrint', gdy urządzenie NIE jest uruchomione, w napicie pojawiają się słowa 'Print' oraz 'Scan'
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_ScanAndPrint_DeviceOff()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOff();
            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multidimensionalDevice.ScanAndPrint();
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja, czy po wywołaniu metody 'Scan', z parametrem określającym format dokumentu zawiera odpowiednie rozszerzenie np.
        /// .jpg // .txt // .pdf, gdy uruchomione jest urządzenie.
        /// Wymagane przekierowanie konsoli do strumienia StringWriter
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_Scan_FormatTypeDocument()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                multidimensionalDevice.Scan(out document, IDocument.FormatType.TXT);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

                multidimensionalDevice.Scan(out document, IDocument.FormatType.JPG);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

                multidimensionalDevice.Scan(out document, IDocument.FormatType.PDF);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        /// <summary>
        /// Weryfikacja ilości wydruku plików przez urządzenie wielofunkcyjne
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_PrintCounter()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            multidimensionalDevice.Print(in doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            multidimensionalDevice.Print(in doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            multidimensionalDevice.Print(in doc3);

            multidimensionalDevice.PowerOff();
            multidimensionalDevice.Print(in doc3);
            multidimensionalDevice.Scan(out doc1);
            multidimensionalDevice.PowerOn();

            multidimensionalDevice.ScanAndPrint();
            multidimensionalDevice.ScanAndPrint();

            // 5 wydruków, gdy urządzenie włączone
            Assert.AreEqual(5, multidimensionalDevice.PrintCounter);
        }

        /// <summary>
        /// Weryfikacja ilości skanów plików przez urządzenie wielofunkcyjne
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_ScanCounter()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            IDocument doc1;
            multidimensionalDevice.Scan(out doc1);
            IDocument doc2;
            multidimensionalDevice.Scan(out doc2);

            IDocument doc3 = new ImageDocument("aaa.jpg");
            multidimensionalDevice.Print(in doc3);

            multidimensionalDevice.PowerOff();
            multidimensionalDevice.Print(in doc3);
            multidimensionalDevice.Scan(out doc1);
            multidimensionalDevice.PowerOn();

            multidimensionalDevice.ScanAndPrint();
            multidimensionalDevice.ScanAndPrint();

            // 4 skany, gdy urzadzenie właczone
            Assert.AreEqual(4, multidimensionalDevice.ScanCounter);
        }

        /// <summary>
        /// Weryfikacja ilości uruchomień urządzenia wielofunkcyjnego
        /// </summary>
        [TestMethod]
        public void MultidimensionalDevice_PowerOnCounter()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();
            multidimensionalDevice.SendFax("+48123123123");
            multidimensionalDevice.PowerOn();
            IDocument documentFax;
            multidimensionalDevice.ReceiveFax(out documentFax);
            multidimensionalDevice.PowerOn();

            IDocument document1;
            multidimensionalDevice.Scan(out document1);
            IDocument document2;
            multidimensionalDevice.Scan(out document2);

            multidimensionalDevice.PowerOff();
            multidimensionalDevice.ReceiveFax(out documentFax);
            multidimensionalDevice.PowerOff();
            multidimensionalDevice.SendFax("+48334321325");
            multidimensionalDevice.PowerOff();
            multidimensionalDevice.PowerOn();

            IDocument document3 = new ImageDocument("aaa.jpg");
            multidimensionalDevice.Print(in document3);

            multidimensionalDevice.PowerOff();
            multidimensionalDevice.Print(in document3);
            multidimensionalDevice.SendFax("+48334321325");
            multidimensionalDevice.Scan(out document1);
            multidimensionalDevice.PowerOn();

            multidimensionalDevice.ScanAndPrint();
            multidimensionalDevice.ScanAndPrint();

            // 3 włączenia
            Assert.AreEqual(3, multidimensionalDevice.Counter);
        }

        [TestMethod]
        public void MultidimensionalDevice_SendFax_DeviceOn()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multidimensionalDevice.SendFax("123456789");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Send fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultidimensionalDevice_SendFax_DeviceOff()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multidimensionalDevice.SendFax("123456789");
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Send fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultidimensionalDevice_ReceiveFax_DeviceOn()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                multidimensionalDevice.ReceiveFax(out document);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Receive fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultidimensionalDevice_ReceiveFax_DeviceOff()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                multidimensionalDevice.ReceiveFax(out document);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Receive fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultidimensionalDevice_SendFax_Counter()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.PowerOn();
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.SendFax("+48884284782");
            IDocument doc1;
            multidimensionalDevice.Scan(out doc1);
            IDocument doc2;
            multidimensionalDevice.Scan(out doc2);
            IDocument doc3 = new PDFDocument("aaa.pdf");
            multidimensionalDevice.Print(in doc3);
            multidimensionalDevice.PowerOff();
            multidimensionalDevice.Print(in doc3);
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.Scan(out doc1);
            multidimensionalDevice.PowerOn();
            multidimensionalDevice.ScanAndPrint();
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.ScanAndPrint();

            Assert.AreEqual(7, multidimensionalDevice.ScanCounter);
            Assert.AreEqual(3, multidimensionalDevice.SendFaxCounter);
        }

        [TestMethod]
        public void MultidimensionalDevice_ReceiveFax_Counter()
        {
            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.PowerOn();
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.SendFax("+48884284782");
            IDocument doc1;
            multidimensionalDevice.ReceiveFax(out doc1);
            IDocument doc2;
            multidimensionalDevice.Scan(out doc2);
            IDocument doc3 = new PDFDocument("aaa.pdf");
            multidimensionalDevice.Print(in doc3);
            multidimensionalDevice.PowerOff();
            multidimensionalDevice.Print(in doc3);
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.ReceiveFax(out doc1);
            multidimensionalDevice.PowerOn();
            multidimensionalDevice.ScanAndPrint();
            multidimensionalDevice.SendFax("+48884284782");
            multidimensionalDevice.ScanAndPrint();

            Assert.AreEqual(4, multidimensionalDevice.PrintCounter);
            Assert.AreEqual(1, multidimensionalDevice.ReceiveFaxCounter);
        }
    }
}