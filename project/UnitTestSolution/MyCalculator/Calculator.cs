namespace MyCalculator
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        
        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("除数不能为零。");
            return (double)a / b;
        }
    }
}
