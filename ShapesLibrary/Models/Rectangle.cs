using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models;

public class Rectangle : IShape
{
    public Rectangle(double firstSide, double secondSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
    }

    private readonly double _firstSide;
    private readonly double _secondSide;

    public double FirstSide
    {
        get => _firstSide;
        private init
        {
            if (value <= 0)
            {
                throw new ShapeException($"Сторона a = {value} не может быть меньше или равна нулю!");
            }
            else
            {
                _firstSide = value;
            }
        }
    }

    public double SecondSide
    {
        get => _secondSide;
        private init
        {
            if (value <= 0)
            {
                throw new ShapeException($"Сторона b = {value} не может быть меньше или равна нулю!");
            }
            else
            {
                _secondSide = value;
            }
        }
    }

    public async Task<double> GetArea() =>
        await Task.Run(() => _firstSide * _secondSide);
}