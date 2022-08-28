namespace CommandPattern.Core
{
    using CommandPattern.Common;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmd = args.Split();
            string name = cmd[0];
            string[] cmdArgs = cmd.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly?
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{name}Command" &&
                               t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (cmdType == null)
            {
                throw new InvalidOperationException(string.Format(Messeges.InvalidCommandType, $"{name}Command"));
            }

            object cmdInstance = Activator.CreateInstance(cmdType);
            MethodInfo executeMethod = cmdType
                .GetMethods()
                .First(m => m.Name == "Execute");
            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
        }
    }
}
