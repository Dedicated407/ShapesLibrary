using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;
using ShapesLibrary.Models;
using Xunit;

namespace TestShapesLibrary;

public class RectangleUnitTest
{
    [Theory]
    [InlineData(5, 5, 5)]
    [InlineData(3.4, 3.4, 3.4)]
    public void IsSidesCorrect(double firstSide, double secondSide, double expected)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        IShape rectangle = factory.Create(firstSide, secondSide);

        // Act
        var result = rectangle as Rectangle;
        
        // Assert
        Assert.Equal(expected, result.FirstSide);
        Assert.Equal(expected, result.SecondSide);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(5, 0)]
    [InlineData(-5.3, 2)]
    [InlineData(2, -2.8)]
    public void IsSidesNotCorrect(double firstSide, double secondSide)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        
        // Act && Assert
        Assert.Throws<ShapeException>(() => factory.Create(firstSide, secondSide));
    }
}