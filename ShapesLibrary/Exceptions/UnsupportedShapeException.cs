namespace ShapesLibrary.Exceptions;

public class UnsupportedShapeException : ShapeException
{
    public UnsupportedShapeException(string message) : base(message)
    {
    }
}