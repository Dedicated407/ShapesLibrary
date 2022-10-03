using System;
using System.Collections.Generic;
using System.Linq;
using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;
using ShapesLibrary.Models;
using Xunit;

namespace TestShapesLibrary;

public class ShapeUnitTest
{
    private const int Rounder = 9;

    private static IEnumerable<object[]> GetCorrectData(int numTests)
    {
        var allData = new List<object[]>
        {
            new object[] {new[] {3.5}, new Tuple<string, double>("Circle", 38.484510006)},
            new object[] {new[] {4.5, 6}, new Tuple<string, double>("Rectangle", 27)},
            new object[] {new double[] {4, 5, 3}, new Tuple<string, double>("Triangle", 6)},
        };

        return allData.Take(numTests);
    }

    private static IEnumerable<object[]> GetIncorrectData(int numTests, int skip = 0)
    {
        var allData = new List<object[]>
        {
            new object[] {new[] {4, 5, 3, 2.5}},
            new object[] {new[] {1, 2, 3, 6, 9, 5.3}},
            new object[] {new double[] {0}},
            new object[] {new[] {-5, 2.4}},
            new object[] {new[] {0, 2.4, 0}},
        };

        return allData.Skip(skip).Take(numTests);
    }

    [Theory]
    [MemberData(nameof(GetCorrectData), parameters: 3)]
    public void IsShapeExist(double[] sides, Tuple<string, double> expected)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        IShape shape = factory.Create(sides);

        // Act
        var result = shape.GetType().Name;

        // Assert
        Assert.Equal(expected.Item1, result);
    }

    [Theory]
    [MemberData(nameof(GetCorrectData), parameters: 3)]
    public void IsShapeAreaCorrect(double[] sides, Tuple<string, double> expected)
    {
        // Arrange
        IShapesFactory factory = new ShapesFactory();
        IShape shape = factory.Create(sides);

        // Act
        var result = shape.GetArea().Result;

        // Assert
        Assert.Equal(expected.Item2, Math.Round(result, Rounder));
    }
    
    [Theory]
    [MemberData(nameof(GetIncorrectData), 2, 0)]
    public void IsShapeNotFound(double[] values)
    {
        IShapesFactory factory = new ShapesFactory();

        Assert.Throws<UnsupportedShapeException>(() => factory.Create(values));
    }
    
    [Theory]
    [MemberData(nameof(GetIncorrectData), 3, 2)]
    public void IsShapeIncorrect(double[] values)
    {
        IShapesFactory factory = new ShapesFactory();

        Assert.Throws<ShapeException>(() => factory.Create(values));
    }
}