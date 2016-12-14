using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var actual = "test";
            actual.Should().StartWith("t").And.Contain("es").And.HaveLength(4);
            
        }


    }
}
