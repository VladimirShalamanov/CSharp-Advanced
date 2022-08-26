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

        public string AnalyzeAccessModifiers(string invastigatedClass)
        {
            Type classType = Type.GetType(invastigatedClass);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }
            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string invastigatedClass)
        {
            Type classType = Type.GetType(invastigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(
               BindingFlags.Instance |
               BindingFlags.Public);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methids of Class: {invastigatedClass}");
            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
