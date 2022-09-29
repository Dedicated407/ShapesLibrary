namespace ShapesLibrary.Interfaces;

public interface IShapeFabric
{
    public IShape Create(params double[] sides);
}