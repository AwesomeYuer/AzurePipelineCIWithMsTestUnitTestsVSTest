namespace ConsoleApp1.Tests
{
    using ConsoleApp1.Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void HelloTest()
        {
            using (ShimsContext.Create())
            {
                var i = 0;
                ShimClass1.AllInstances.HelloString = (sender, whom) =>
                {
                    i++;
                    //sender.Hello(who);
                    Console.WriteLine($"Good Bye {whom}");
                };
                var c1 = new Class1();
                c1.Hello("world");

            }

        }
    }
}