using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace MoqLab
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MoqTests
    {
        [TestMethod]
        public void ConstructorTest_NoParam()
        {
            var target=new Mock<MyTestClass>();
            var param = "test";
            target.Setup(s => s.DoSomeThing(param)).Callback(() => Console.WriteLine("fake method")).Returns(true);
            
            var actual= target.Object.DoSomeThing(param);

            target.Verify(v => v.DoSomeThing(param), Times.Once());
            Assert.IsTrue(actual);
        }
    }

    public class MyTestClass
    {

        public virtual bool DoSomeThing(string param)
        {
            Console.WriteLine("DoSomeThing!");
            return false;
        }
    }
}
