namespace VsPlay
{
    public class Base
    {
    }

    public class SymbolFileBase: Base
    {
    }

    public class SampleEntity : SymbolFileBase
    {
        public SampleEntity()
        {
        }

        public int AValue = 1;
        public int? NullableValue;
    }

    public class SampleQuest : SymbolFileBase
    {
        public SampleQuest()
        {
        }

        public string BValue = "B";
    }
}

