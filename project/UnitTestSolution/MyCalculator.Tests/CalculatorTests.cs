namespace MyCalculator.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Subtract_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 4;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Multiply_ReturnsCorrectProduct()
    {
        // Arrange
        int a = 7;
        int b = 6;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Divide_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 20;
        int b = 4;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }
}

