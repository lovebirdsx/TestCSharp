namespace VsPlay
{
    public class Base
    {
        public string Type { get; set; } = "unknown";
    }

    public class A : Base
    {
        public A()
        {
            Type = "A";
            AValue = 0;
        }

        public int AValue { get; set; }
    }

    public class B : Base
    {
        public B()
        {
            Type = "B";
            BValue = "B";
        }

        public string BValue { get; set; }
    }
}

