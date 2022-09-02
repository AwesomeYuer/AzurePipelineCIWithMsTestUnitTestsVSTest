namespace ConsoleApp1.Tests
{
    using ChinaCPPMigTransLayer.MSTest.UnitTests;
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
                ShimClass1.AllInstances.HelloStringString = (sender, whom, whom2) =>
                {
                    i++;
                    var r = $"Shim Good Bye {whom}, {whom2}";
                    Console.WriteLine(r);
                    return r;
                };
                var c1 = new Class1();
                var r = c1.Hello("world", "world2");
                Assert.IsTrue(r.StartsWith("shim", StringComparison.OrdinalIgnoreCase));
            }
        }

        [TestMethod()]
        public void HelloTest2()
        {
            //Fakes stubClass1 = new Fakes.StubClass1();
            var stubIHello = new StubIHello()
            { 
                 HelloStringString = (whom, whom2) =>
                 {
                     var r = $"Stub Good Bye {whom}, {whom2}";
                     Console.WriteLine(r);
                     return r;
                 }
            };
            Invoker a = new (stubIHello);
            var r = a.Invoke("world", "world2");
            Assert.IsTrue(r.StartsWith("stub", StringComparison.OrdinalIgnoreCase));
        }

        [DataRow(typeof(ArgumentNullException))]
        //[DataRow(typeof(DivideByZeroException))]
        //[DataRow(typeof(Exception))]
        [TestMethod()]
        public void ExceptionTest(Type type)
        {
            AssertHelper
                    .Throws
                        (
                            type
                            , () =>
                            {
                                throw new ArgumentNullException();
                            }
                        );
        }
        
        [TestMethod()]
        public void ExceptionTest2()
        {
            AssertHelper
                    .Throws<DivideByZeroException>
                        (
                            () =>
                            {
                                throw new DivideByZeroException();
                            }
                        );
        }
    }
}