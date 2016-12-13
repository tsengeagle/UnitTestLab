using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using Moq;
using Moq.Protected;
using NSubstitute;

namespace UnitTestLab
{
    public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
        }

        [TestMethod]
        public void MyTestMethod()
        {
            Assert.IsTrue(true);
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void ValueAssert_ExpectedEqualActual()
        {
            string actualValue = "test";
            string expectedValue = "test";
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ValueAssert_StatusIsTrue()
        {
            bool actualStatus = true;
            Assert.IsTrue(actualStatus);
        }

        [TestMethod]
        public void ObjectAssert_AreEqualWillFailBecouseReference()
        {
            var expected = new List<string>() { "a", "b", "c" };
            var actual = new List<string>() { "a", "b", "c" };
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void AssertObjectEqual_WithExpectedObject()
        {
            var expected = new List<string>() { "a", "b", "c" };
            var actual = new List<string>() { "a", "b", "c" };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [TestMethod]
        public void AssertObjectNotEqual_WithExpectedObject()
        {
            var expected = new List<string>() { "a", "b", "c" };
            var actual = new List<string>() { "a", "b" };
            expected.ToExpectedObject().ShouldNotEqual(actual);
        }

        [TestMethod]
        public void ObjectAssert_ComplexObject()
        {
            var expected = new { id = 1, name = "test" };
            var actual = new { id = 1, name = "test" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void ObjectAssert_ComplexObject_PartialMatch()
        {
            var expected = new { name = "test" };
            var actual = new { id = 1, name = "test" };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [TestMethod]
        public void MockLab_GetTime_UseNSub()
        {
            //arrange
            var expected = new DateTime(2016,12,1);
            var target = Substitute.For<MyMockLab>();
            target.CurrentTime().Returns(new DateTime(2016, 12, 1));
            //act
            var actual = target.GetCorrectTime();
            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void MockLab_GetTime_UseMoq()
        {
            //arrange
            var expected = new DateTime(2016, 12, 1);
            var mock = new Mock<MyMockLab>();
            mock.Setup(s => s.CurrentTime()).Returns(new DateTime(2016, 12, 1));

            var target = mock.Object;
            //act
            var actual = target.GetCorrectTime();
            //assert
            Assert.AreEqual(expected, actual);

        }
    }

    public class MyMockLab
    {
        public DateTime GetCorrectTime()
        {
            return CurrentTime();
        }

        public virtual DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}
