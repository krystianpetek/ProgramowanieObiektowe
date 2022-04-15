using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Time_TimePeriod;

namespace TimeTests
{
    [TestClass]
    internal class TimeToStringTests
    {
        //[TestMethod, TestCategory("String representation")]
        //public void ToString_Default_Culture_EN()
        //{
        //    var p = new Pudelko(2.5, 9.321);
        //    string expectedStringEN = "2.500 m × 9.321 m × 0.100 m";

        //    Assert.AreEqual(expectedStringEN, p.ToString());
        //}

        //[DataTestMethod, TestCategory("String representation")]
        //[DataRow(null, 2.5, 9.321, 0.1, "2.500 m × 9.321 m × 0.100 m")]
        //[DataRow("m", 2.5, 9.321, 0.1, "2.500 m × 9.321 m × 0.100 m")]
        //[DataRow("cm", 2.5, 9.321, 0.1, "250.0 cm × 932.1 cm × 10.0 cm")]
        //[DataRow("mm", 2.5, 9.321, 0.1, "2500 mm × 9321 mm × 100 mm")]
        //public void ToString_Formattable_Culture_EN(string format, double a, double b, double c, string expectedStringRepresentation)
        //{
        //    var p = new Pudelko(a, b, c, unit: UnitOfMeasure.meter);
        //    Assert.AreEqual(expectedStringRepresentation, p.ToString(format));
        //}

        //[TestMethod, TestCategory("String representation")]
        //[ExpectedException(typeof(FormatException))]
        //public void ToString_Formattable_WrongFormat_FormatException()
        //{
        //    var p = new Pudelko(1);
        //    var stringformatedrepreentation = p.ToString("wrong code");
        //}
    }
}
