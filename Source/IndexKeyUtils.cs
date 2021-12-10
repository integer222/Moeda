using System;
using MicroLibs.Moeda.Qualifiers;

namespace MicroLibs.Moeda
{
    internal static class IndexKeyUtils
    {
        public static string CreateKey(Type type, IQualifier qualifier)
        {
            var qualifierValue = qualifier != null ? $":q:{qualifier.Value}" : "";
            return $"t:{type.FullName}{qualifierValue}";
        }
    }
}