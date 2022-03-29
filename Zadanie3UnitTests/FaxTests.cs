using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie3.Device;
using Zadanie3.Document;

namespace Zadanie3UnitTests
{
    [TestClass]
    public class FaxTests
    {
        /// <summary>
        /// Weryfikacja czy urządzenie jest wyłączone
        /// </summary>
        [TestMethod]
        public void Fax_GetState_StateOff()
        {
            var fax = new Fax();
            fax.PowerOff();
            Assert.AreEqual(IDevice.State.OFF, fax.GetState());
        }

        /// <summary>
        /// Weryfikacja czy urządzenie jest włączone
        /// </summary>
        [TestMethod]
        public void Fax_GetState_StateOn()
        {
            var fax = new Fax();
            fax.PowerOn();
            Assert.AreEqual(IDevice.State.ON, fax.GetState());
        }

        /// <summary>
        /// Weryfikacja ilości uruchomień urządzenia wielofunkcyjnego
        /// </summary>
        [TestMethod]
        public void Fax_PowerOnCounter()
        {
            var fax = new Fax();
            fax.PowerOn();
            fax.SendFax("+48123123123");
            fax.PowerOn();
            IDocument documentFax;
            fax.ReceiveFax(out documentFax);
            fax.PowerOn();

            fax.PowerOff();
            fax.ReceiveFax(out documentFax);
            fax.PowerOff();
            fax.SendFax("+48334321325");
            fax.PowerOff();
            fax.PowerOn();

            fax.PowerOff();
            fax.SendFax("+48334321325");
            fax.PowerOn();
            // 3 włączenia
            Assert.AreEqual(3, fax.Counter);
        }

        [TestMethod]
        public void Fax_SendFax_DeviceOn()
        {
            var fax = new Fax();
            fax.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                fax.SendFax("123456789");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Send fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Fax_SendFax_DeviceOff()
        {
            var fax = new Fax();
            fax.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                fax.SendFax("123456789");
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Send fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Fax_ReceiveFax_DeviceOn()
        {
            var fax = new Fax();
            fax.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                fax.ReceiveFax(out document);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Receive fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Fax_ReceiveFax_DeviceOff()
        {
            var fax = new Fax();
            fax.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument document;
                fax.ReceiveFax(out document);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Receive fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Fax_SendFax_Counter()
        {
            var fax = new Fax();
            fax.SendFax("+48884284782");
            fax.PowerOn();
            fax.SendFax("+48884284782");
            fax.SendFax("+48884284782");
            fax.PowerOff();
            fax.SendFax("+48884284782");
            fax.PowerOn();
            fax.SendFax("+48884284782");

            Assert.AreEqual(3, fax.SendFaxCounter);
        }

        [TestMethod]
        public void Fax_ReceiveFax_Counter()
        {
            var fax = new Fax();
            fax.SendFax("+48884284782");
            fax.PowerOn();
            fax.SendFax("+48884284782");
            fax.SendFax("+48884284782");
            IDocument doc1;
            fax.ReceiveFax(out doc1);
            fax.PowerOff();
            fax.SendFax("+48884284782");
            fax.ReceiveFax(out doc1);
            fax.PowerOn();
            fax.SendFax("+48884284782");

            Assert.AreEqual(1, fax.ReceiveFaxCounter);
        }

    }
}