namespace ForMindbox;

public class Triangle : IFigure
{
    private readonly double[] sides;

    /// <summary>
    /// Creates new triangle from lengths of its sides.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">When any of sides have negative length</exception>
    public Triangle(double seg1, double seg2, double seg3) : this(new[] {seg1, seg2, seg3})
    {
    }

    /// <summary>
    /// Creates new rectangle from length of its sides.
    /// </summary>
    /// <param name="sides"></param>
    /// <exception cref="ArgumentException">When invalid number of sides is given</exception>
    /// <exception cref="ArgumentOutOfRangeException">When any of sides have negative length</exception>
    public Triangle(double[] sides)
    {
        if (sides.Length != 3)
        {
            throw new ArgumentException("Expected exactly three sides", nameof(sides));
        }

        if (sides.Any(side => side < 0))
        {
            throw new ArgumentOutOfRangeException(nameof(sides), "All sides must have nonnegative length");
        }

        Array.Sort(sides);
        this.sides = sides;

        if (Shortest + Medium < Longest)
        {
            throw new ArgumentException("This rectangle is not possible", nameof(sides));
        }
    }

    public double Shortest => sides[0];
    public double Medium => sides[1];
    public double Longest => sides[2];

    /// <summary>
    /// Returns perimiter of this triangle.
    /// </summary>
    public double Perimeter => sides.Sum();

    /// <inheritdoc />
    public double ComputeArea()
    {
        if (IsRectangular())
        {
            return Shortest * Medium / 2;
        }

        var halfPerimeter = Perimeter / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - sides[0]) * (halfPerimeter - sides[1]) *
                         (halfPerimeter - sides[2]));
    }

    public bool IsRectangular(double precision = 0.000001)
    {
        var found = Shortest * Shortest + Medium * Medium;
        var expected = Longest * Longest;
        return Math.Abs(found - expected) < precision;
    }
}