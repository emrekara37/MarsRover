using MarsRover.Domain.Contracts;
using MarsRover.Domain.Shared;

namespace MarsRover.Domain.Rovers;

public class CuriosityRover : Rover
{
    public CuriosityRover(int coordinateX, int coordinateY, Direction direction, IPlateau plateau) : base(coordinateX, coordinateY, direction, plateau)
    {
    }

    public override int Speed => 1;
    public override string Name => "Curiosity";
}