using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;
using ShapesLibrary.Models;
using Xunit;

namespace TestShapesLibrary;

public class TriangleUnitTest
{
    [Theory]
    [InlineData(5, 5, 5, 5)]
    [InlineData(3.4, 3.4, 3.4, 3.4)]
    public void IsSidesCorrect(double firstSide, double secondSide, double thirdSide, double expected)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        IShape triangle = factory.Create(firstSide, secondSide, thirdSide);

        // Act
        var result = triangle as Triangle;
        
        // Assert
        Assert.Equal(expected, result.FirstSide);
        Assert.Equal(expected, result.SecondSide);
        Assert.Equal(expected, result.ThirdSide);
    }

    [Theory]
    [InlineData(0, 5, 2)]
    [InlineData(5, 0, 2)]
    [InlineData(2, 5, 0)]
    [InlineData(2, 5, 3)]
    [InlineData(-5.3, 2, 2)]
    [InlineData(2, -2.8, 4)]
    [InlineData(2, 4, -2.8)]
    public void IsSidesNotCorrect(double firstSide, double secondSide, double thirdSide)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        
        // Act && Assert
        Assert.Throws<ShapeException>(() => factory.Create(firstSide, secondSide, thirdSide));
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(13, 12, 5)]
    [InlineData(7, 25, 24)]
    public void IsRight(double firstSide, double secondSide, double thirdSide)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        IShape triangle = factory.Create(firstSide, secondSide, thirdSide);
        
        // Act
        var result = triangle as Triangle;
        
        // Assert
        Assert.True(result.IsRight());
    }
}