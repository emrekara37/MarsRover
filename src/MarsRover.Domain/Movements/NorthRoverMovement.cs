using MarsRover.Domain.Contracts;
using MarsRover.Domain.Shared;

namespace MarsRover.Domain.Movements;

public sealed class NorthRoverMovement : RoverMovement
{
    public NorthRoverMovement(IRover rover) : base(rover)
    {
    }

    public override void MoveForward()
    {
        Rover.CoordinateY += Rover.Speed;
    }

    public override void MoveLeft()
    {
        Rover.Direction = Direction.W;
    }

    public override void MoveRight()
    {
        Rover.Direction = Direction.E;
    }
}