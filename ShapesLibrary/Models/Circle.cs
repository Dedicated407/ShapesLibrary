using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models;

public class Circle : IShape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    private readonly double _radius;

    public double Radius
    {
        get => _radius;
        private init
        {
            if (value <= 0)
            {
                throw new ShapeException($"Радиус r = {value} не может быть меньше или равен нулю!");
            }

            _radius = value;
        }
    }

    public async Task<double> GetArea() => 
        await Task.Run(() => Math.PI * Math.Pow(_radius, 2));
}