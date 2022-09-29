using ShapesLibrary.Exceptions;
using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models;

public class Triangle : IShape
{
    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
        
        if (IsNotExist())
        {
            throw new ShapeException("Данный треугольник не существует!");
        }
    }

    private readonly double _firstSide;
    private readonly double _secondSide;
    private readonly double _thirdSide;
    
    public double FirstSide
    {
        get => _firstSide;
        private init
        {
            if (value <= 0)
            {
                throw new ShapeException($"Сторона треугольника a = {value} не может быть меньше или равна нулю!");
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
                throw new ShapeException($"Сторона треугольника b = {value} не может быть меньше или равна нулю!");
            }
            else
            {
                _secondSide = value;
            }
        }
    }

    public double ThirdSide
    {
        get => _thirdSide;
        private init
        {
            if (value <= 0)
            {
                throw new ShapeException($"Сторона треугольника c = {value} не может быть меньше или равна нулю!");
            }
            else
            {
                _thirdSide = value;
            }
        }
    }

    /// <summary>
    /// Нахождение площади треугольника по формуле Герона
    /// </summary>
    /// <returns>Площадь треугольника</returns>
    public async Task<double> GetArea()
    {
        var halfPerimeter = (FirstSide + SecondSide + ThirdSide) / 2d;
        
        return await Task.Run(() => 
            Math.Sqrt(halfPerimeter * (halfPerimeter - FirstSide) * (halfPerimeter - SecondSide) * (halfPerimeter - ThirdSide))
        );
    }

    /// <summary>
    /// Проверка на не существования треугольника.
    /// </summary>
    /// <returns>Если не существует - true, иначе - false</returns>
    private bool IsNotExist() => 
        _firstSide + _secondSide <= _thirdSide ||
        _firstSide + _thirdSide <= _secondSide ||
        _secondSide + _thirdSide <= _firstSide;
}