using System;
using System.Collections.Generic;

namespace VsPlay
{
    public static class TypeMapping
    {
        private static readonly Dictionary<string, Type> Mapping = new()
        {
            { nameof(SampleEntity), typeof(SampleEntity) },
            { nameof(SampleQuest), typeof(SampleQuest) }
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

