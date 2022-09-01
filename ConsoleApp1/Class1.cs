namespace ConsoleApp1
{
    using System;
    public interface IHello
    {
        string Hello(string whom, string whom2);
    }
    public class Class1 : IHello
    {
        public string Hello(string whom, string whom2) 
        {
            var r = $"Hello:{whom}{whom2}";
            Console.WriteLine(r);
            return r;
        }  
    }
    public class Analyzer
    {
        private IHello _hello;
        public Analyzer(IHello hello)
        {
            _hello = hello;
        }
        public string Invoke(string whom, string whom2)
        {
            return _hello.Hello(whom, whom2);
        }
    }
}
