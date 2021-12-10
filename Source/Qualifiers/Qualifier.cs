namespace MicroLibs.Moeda.Qualifiers
{
    public class Qualifier : IQualifier
    {
        public string Value { get; }

        public Qualifier(string value)
        {
            Value = value;
        }
    }
}