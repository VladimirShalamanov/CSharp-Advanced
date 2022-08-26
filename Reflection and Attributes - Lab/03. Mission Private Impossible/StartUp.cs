namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result1 = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result1);
        }
    }
}
