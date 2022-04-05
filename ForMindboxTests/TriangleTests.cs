using System;
using ForMindbox;
using Xunit;

namespace ForMindboxTests;

public class TriangleTests
{
    [Fact]
    public void InvalidTriangle()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 0, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -1, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, -1));
    }

    [Fact]
    public void ThinTriangle()
    {
        var triangle = new Triangle(3, 2, 1);
        Assert.Equal(0, triangle.ComputeArea());
        Assert.Equal(3, triangle.Longest);
        Assert.Equal(2, triangle.Medium);
        Assert.Equal(1, triangle.Shortest);
    }

    [Fact]
    public void ImpossibleTriangle()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 100));
    }

    [Fact]
    public void UsualTriangle()
    {
        var triangle = new Triangle(4, 5, 6);
        Assert.Equal(9.921567, triangle.ComputeArea(), 6);
        Assert.Equal(6, triangle.Longest);
        Assert.Equal(5, triangle.Medium);
        Assert.Equal(4, triangle.Shortest);
    }

    [Fact]
    public void RectangluarTriangle()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.ComputeArea());
        Assert.True(triangle.IsRectangular());
    }

    [Fact]
    public void ZeroTriangle()
    {
        var triangle = new Triangle(0, 0, 0);
        Assert.Equal(0, triangle.ComputeArea());
        // This is weird case, but let's agree that this triangle is rectangular.
        Assert.True(triangle.IsRectangular());
    }
}