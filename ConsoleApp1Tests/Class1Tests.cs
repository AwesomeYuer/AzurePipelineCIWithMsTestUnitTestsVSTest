﻿namespace ConsoleApp1.Tests
{
    using Microshaoft.UnitTesting.MsTest;
    using ConsoleApp1.Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void HelloConstructorTest()
        {
            using (ShimsContext.Create())
            {
                var i = 0;
                ShimClass1.ConstructorString = (@this, hello) =>
                {
                    //var r = new Class1("nihao");
                    //new ShimClass1(@this);
                    //啥也不是!就虚构实例化出来了!
                };
                var hello = "你好";
                var c1 = new Class1(hello);
                var r = c1.Hello("world", "world2");
                Assert
                    .IsTrue
                        (
                            r.StartsWith
                                    (
                                        hello
                                        , StringComparison.OrdinalIgnoreCase
                                    )
                        );
            }
        }


       // [TestMethod()]
        public void HelloTest()
        {
            using (ShimsContext.Create())
            {
                var i = 0;
                ShimClass1
                        .AllInstances
                        .HelloStringString =
                                (sender, whom, whom2) =>
                                {
                                    i++;
                                    var r = $"Shim Good Bye {whom}, {whom2}";
                                    Console.WriteLine($"Shiming return {r}");
                                    return r;
                                };
                var c1 = new Class1("你好");
                var r = c1.Hello("world", "world2");
                Assert
                    .IsTrue
                        (
                            r.StartsWith
                                    (
                                        "shim"
                                        , StringComparison.OrdinalIgnoreCase
                                    )
                        );
            }
        }

        [TestMethod()]
        public void HelloTest2()
        {
            //Fakes stubClass1 = new Fakes.StubClass1();
            var stubIHello = new StubIHello()
            { 
                 HelloStringString =
                    (whom, whom2) =>
                    {
                        var r = $"Stub Good Bye {whom}, {whom2}";
                        Console.WriteLine($"Stubing return {r}");
                        return r;
                    }
            };
            Invoker invoker = new (stubIHello);
            var r = invoker.Invoke("world", "world2");
            Assert
                .IsTrue
                    (
                        r.StartsWith
                                (
                                    "Stub"
                                    , StringComparison.OrdinalIgnoreCase
                                )
                    );
        }

        [DataRow(typeof(DivideByZeroException), $"Message of {nameof(DivideByZeroException)}")]
        [DataRow(typeof(DivideByZeroException), "")]
        [DataRow(typeof(DivideByZeroException), null)]
        //[DataRow(typeof(DivideByZeroException))]
        //[DataRow(typeof(Exception))]
        [TestMethod()]
        public void ExceptionTest
                            (
                                Type expectedExceptionType
                                , string expectedExceptionMessage = null!
                            )
        {
            Assert
                    .That
                    .Throws
                        (
                            expectedExceptionType
                            , () =>
                            {
                                throw
                                    new
                                        DivideByZeroException
                                            (
                                                expectedExceptionMessage + "1111"
                                                , new Exception()
                                            );
                            }
                            , expectedExceptionMessage
                            , (x) =>
                            {
                                Assert.IsTrue(x is DivideByZeroException);
                                Assert.AreEqual(x.GetType(), typeof(DivideByZeroException));
                            }
                        );
        }

        [DataRow($"Message of {nameof(ArgumentNullException)}")]
        [DataRow("")]
        [DataRow(null)]
        [TestMethod()]
        public void ExceptionTest2(string expectedExceptionMessage = null!)
        {
            Assert
                    .That
                    .Throws
                        <ArgumentNullException>
                            (
                                () =>
                                {
                                    throw
                                        new
                                            ArgumentNullException
                                                (
                                                    expectedExceptionMessage
                                                    , new Exception()
                                                );
                                }
                                , expectedExceptionMessage
                                , (x) =>
                                {
                                    Assert.IsTrue(x is ArgumentNullException);
                                    Assert.AreEqual(x.GetType(), typeof(ArgumentNullException));
                                }
                            );
        }
        
        //[DataRow(typeof(DivideByZeroException))]
        //[DataRow(typeof(Exception))]
        [TestMethod()]
        public void ExceptionTest3()
        {
            // fail
            Assert
                .ThrowsException<DivideByZeroException>
                    (
                        () =>
                        { 
                            Task
                                .Run
                                    (
                                        ()=>
                                        {
                                            var e = new DivideByZeroException("hello");
                                            throw e;
                                        }
                                    )
                                .Wait();
                            
                        }
                        , "hello11111"
                    );
        }
    }
}
