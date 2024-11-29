using System;
using System.Collections.Generic;

namespace VsPlay
{
    public static class TypeMapping
    {
        private static readonly Dictionary<string, Type> Mapping = new()
        {
            { "A", typeof(A) },
            { "B", typeof(B) }
            // 添加更多类型映射
        };

        public static Type GetType(string typeName)
        {
            if (Mapping.TryGetValue(typeName, out var type))
            {
                return type;
            }
            return typeof(Base);
        }
    }
}

