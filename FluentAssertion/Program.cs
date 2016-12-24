using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;

namespace FluentAssertion
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var actual = "test3";
            actual.Should().StartWith("t").And.Contain("es").And.HaveLength(5);
            
            Assert.IsTrue(actual.StartsWith("t"));
            Assert.IsTrue(actual.Contains("es"));
            Assert.AreEqual(5,actual.Length);
            
        }
    }

}
