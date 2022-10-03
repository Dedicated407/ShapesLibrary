using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models;

public class ShapesFactory : IShapesFactory
{
    public IShape Create(params double[] sides) => sides.Length switch
    {
        3 => new Triangle(sides[0], sides[1], sides[2]),
        2 => new Rectangle(sides[0], sides[1]),
        1 => new Circle(sides[0]),
        _ => throw new UnsupportedShapeException("Не найдена подходящая фигура.")
    };
}