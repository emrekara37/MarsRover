using MarsRover.Domain.Shared;

namespace MarsRover.Domain.Contracts;

public interface IRover
{
    int Speed { get; }
    string Name { get; }
    IPlateau Plateau { get; }
    int CoordinateX { get; set; }
    int CoordinateY { get; set; }
    Direction Direction { get; set; }
    void Move(Movement movement);
}