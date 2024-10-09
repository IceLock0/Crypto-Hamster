using System;

namespace Utils
{
    public static class TypeExtension
    {
        public static Type GetTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return null;
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(typeName);
                if (type != null)
                    return type;
            }
            
            return null;
        }
    }
}