using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Time_TimePeriod;

namespace TimeTests
{
    [TestClass]
    public class TimeConstructorTests
    {
        [DataTestMethod,TestCategory("Constructor")]
        [DataRow(0,0,0,0,0,0)]
        [DataRow(0,0,0,0,0,0)]
        [DataRow(0,0,0,0,0,0)]
        [DataRow(0,0,0,0,0,0)]
        [DataRow(23,59,59,23,59,59)]
        public void ConstructorThreeParameters_WhenGivenThreeCorrectParameters_ShouldReturnAreEqualsTrue(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Assert.AreEqual((byte)expectedHours, time.Hours);
            Assert.AreEqual((byte)expectedMinutes, time.Minutes);
            Assert.AreEqual((byte)expectedSeconds, time.Seconds);
        }
        
        [DataTestMethod,TestCategory("Constructor")]
        [DataRow(1,1,1,3,5,2)]
        [DataRow(1,1,1,23,59,59)]
        [DataRow(0,0,0,12,12,10)]
        [DataRow(10,12,14,0,1,59)]
        [DataRow(23,59,59,24,60,60)]
        public void ConstructorThreeParameters_WhenGivenThreeCorrectParametersAndExpectedWrongParameters_ShouldReturnAreNotEqualsTrue(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Assert.AreNotEqual((byte)expectedHours, time.Hours);
            Assert.AreNotEqual((byte)expectedMinutes, time.Minutes);
            Assert.AreNotEqual((byte)expectedSeconds, time.Seconds);
        }
        
        [DataTestMethod,TestCategory("Constructor")]
        [DataRow(-1, 0, 0)]
        [DataRow(0, -1, 0)]
        [DataRow(0, 0, -1)]
        [DataRow(-1, -1, 0)]
        [DataRow(-1, 0, -1)]
        [DataRow(0, -1, -1)]
        [DataRow(-1, -1, -1)]
        [DataRow(23,59,60)]
        [DataRow(23,60,60)]
        [DataRow(24,60,60)]
        [DataRow(-1,59,59)]
        [DataRow(-1,60,59)]
        [DataRow(-1,60,60)]
        [DataRow(-1,-1,60)]
        [DataRow(0,-1,60)]
        [DataRow(-1,0,60)]
        [DataRow(-1,60,0)]
        [DataRow(24,0,0)]
        [DataRow(24,-1,-1)]
        [DataRow(24,0,-1)]
        [DataRow(24,-1,0)]
        [DataRow(24,59,59)]
        [DataRow(24,60,59)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorThreeParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes, int seconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
        }


        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(23, 59, 23, 59)]
        public void ConstructorTwoParameters_WhenGivenTwoCorrectParameters_ShouldReturnAreEqualsTrue(
            int hours, int minutes,
            int expectedHours, int expectedMinutes)
        {
            Time time = new Time((byte)hours, (byte)minutes);
            Assert.AreEqual((byte)expectedHours, time.Hours);
            Assert.AreEqual((byte)expectedMinutes, time.Minutes);
            Assert.AreEqual((byte)0, time.Seconds);
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(23, 59, 23, 59)]
        public void ConstructorTwoParameters_WhenGivenTwoCorrectParametersAndExpectedWrongParameters_ShouldReturnAreNotEqualsTrue(
            int hours, int minutes,
            int expectedHours, int expectedMinutes)
        {
            Time time = new Time((byte)hours, (byte)minutes);
            Assert.AreEqual((byte)expectedHours, time.Hours);
            Assert.AreEqual((byte)expectedMinutes, time.Minutes);
            Assert.AreEqual((byte)0, time.Seconds);
        }

        [DataTestMethod, TestCategory("Constructor")]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(-1,-1)]
        [DataRow(23, 60)]
        [DataRow(24, 59)]
        [DataRow(24, 60)]
        [DataRow(-1, 59)]
        [DataRow(-1, 60)]
        [DataRow(0, 60)]
        [DataRow(24, 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTwoParameters_WhenGivenWrongParameters_ShouldThrowArgumentOutOfRangeException(
            int hours, int minutes)
        {
            Time time = new Time((byte)hours, (byte)minutes);
        }
    }
}