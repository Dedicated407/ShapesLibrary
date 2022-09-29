namespace ShapesLibrary.Interfaces;

public interface IShapesFactory
{
    public IShape Create(params double[] sides);
}