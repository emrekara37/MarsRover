using MarsRover.Domain.Contracts;

namespace MarsRover.Domain;

public class MarsPlateau : IPlateau
{
    public MarsPlateau(int coordinateX, int coordinateY)
    {
        CoordinateX = coordinateX;
        CoordinateY = coordinateY;
    }

    public int CoordinateX { get; }
    public int CoordinateY { get; }
}