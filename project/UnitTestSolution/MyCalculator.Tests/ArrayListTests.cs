namespace MyCalculator.Tests;

public class ArrayListTests 
{
    [Fact]
    public void ArrayAppend_Ok_ReturnsCorrectArray() {
        int[] array = [1, 2, 3];

        int[] array2 = [.. array, 4];
        
        Assert.Equal([1, 2, 3, 4], array2);
    }

    [Fact]
    public void ListAppend_Ok_ReturnsCorrectList() {
        List<int> list = [ 1, 2, 3 ];

        list.Add(4);
        
        Assert.Equal([ 1, 2, 3, 4 ], list);
    }
}