using System;
using ForMindbox;
using Xunit;

namespace ForMindboxTests;

public class CircleTests
{
    [Fact]
    public void ZeroSized()
    {
        var circle = new Circle(0);
        Assert.Equal(0, circle.ComputeArea());
    }

    [Fact]
    public void NegativeRadius()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [Fact]
    public void NormalCircle()
    {
        var circle = new Circle(1);
        Assert.Equal(Math.PI, circle.ComputeArea());
    }
}