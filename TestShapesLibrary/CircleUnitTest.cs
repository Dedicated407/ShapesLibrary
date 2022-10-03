using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;
using ShapesLibrary.Models;
using Xunit;

namespace TestShapesLibrary;

public class CircleUnitTest
{
    [Theory]
    [InlineData(5, 5)]
    [InlineData(3.4, 3.4)]
    public void IsRadiusCorrect(double radius, double expected)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        IShape circle = factory.Create(radius);

        // Act
        var result = (circle as Circle)!.Radius;

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5.3)]
    public void IsRadiusNotCorrect(double radius)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();

        // Act && Assert
        Assert.Throws<ShapeException>(() => factory.Create(radius));
    }
}