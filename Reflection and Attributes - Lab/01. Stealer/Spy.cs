namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string spy { get; set; }
        public Spy()
        {
            
        }

        public string StealFieldInfo(string invastigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(invastigatedClass);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public);
            StringBuilder stringBuilder = new StringBuilder();

            Object classIntance = Activator.CreateInstance(classType, new object[] { });
            stringBuilder.AppendLine($"Class under investigation: {invastigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classIntance)}");
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
