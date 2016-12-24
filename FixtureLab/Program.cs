using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace FixtureLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDates = new Fixture().CreateMany<DateTime>();
            foreach (var item in myDates.ToList())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();

        }
    }

    [TestFixture]
    public class FixtureLabTests
    {
        Fixture fixture;
        public FixtureLabTests()
        {
            fixture = new Fixture();
        }

        [Test]
        public void FirstTest()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void FixtureTest()
        {
            var myData = fixture.Build<MyShift>().OmitAutoProperties().With<string>(x => x.Name, "myValue").Create();

        }
    }

    internal class MyShift
    {
        public string Name { get; set; }
    }
}
