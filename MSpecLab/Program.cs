using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Machine.Specifications.Model;

namespace MSpecLab
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string SayHello()
        {
            return "Hello world";
        }

        internal string SayHello(string myName)
        {
            return "Hello world! " + myName;
        }
    }

    [Subject(typeof(Program), "Say Hello")]
    public class HelloWorld
    {
        private static Program Subject;

        Establish context = () =>
        {
            // ... any mocking, stubbing, or other setup ...
            Subject = new Program();
        };

        private Because of = () => message = Subject.SayHello();

        private It Should_Get_Hello_World = () => message.ShouldEqual<string>("Hello world");

        private Cleanup after = () =>
        {
            Subject = null;
        };

        private static string message;
    }

    [Subject(typeof(Program), "Say Hello to my name")]
    public class HelloToSomeone
    {
        private Establish context = () =>
        {
            Subject = new Program();
            MyName = "eagle";
            expected = "Hello world! " + MyName;
        };
        private static Program Subject;
        It Should_Get_Hello_World_And_MyName=()=>message.ShouldEqual(expected);
        private Because of = () => message = Subject.SayHello(MyName);
        private static string MyName;
        private static string message;
        private static string expected;
    }
}
