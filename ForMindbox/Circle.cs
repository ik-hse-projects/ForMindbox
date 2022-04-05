namespace ForMindbox;

public class Circle : IFigure
{
    /// <summary>
    /// Creates Circle figure based on its radius.
    /// </summary>
    /// <param name="radius">Radius of the circle</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when radius is less than zero</exception>
    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius));
        }

        Radius = radius;
    }

    /// <summary>
    /// Radius of this circle
    /// </summary>
    public double Radius { get; }

    /// <inheritdoc />
    public double ComputeArea()
    {
        return Math.PI * Radius * Radius;
    }
}