namespace CommandPattern.Core
{
    using IO.Contracts;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        private readonly IReader reader;
        private readonly IWriter writer;
        private ICommandInterpreter command;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();
                string result = this.commandInterpreter.Read(input);
                this.writer.WriteLine(result);
            }
        }
    }
}
