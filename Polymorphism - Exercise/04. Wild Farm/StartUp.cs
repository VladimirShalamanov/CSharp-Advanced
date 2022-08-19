namespace P04.WildFarm
{
    using P04.WildFarm.Core;
    using P04.WildFarm.IO;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
