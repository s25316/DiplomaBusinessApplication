using System.Reflection;

namespace Teryt.Factories
{
    public static class MessagesFactory
    {
        public static string GenerateExeptionMessage(string description, Type classType, MethodBase? method, string inputData)
        {
            return string.Format
                (
                "{0}{1}; {2}{3}; {4}{5};",
                "Description: ",
                description,
                "Class: ",
                classType.FullName,
                "Method: ",
                (method == null) ? "None" : method.Name,
                "InputData: ",
                inputData
                );
        }
    }
}