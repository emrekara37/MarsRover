using MarsRover.Domain.Contracts;
using MarsRover.Domain.Shared;

namespace MarsRover.Domain.Movements;

public sealed class SouthDirectionMovement : RoverMovement
{
    public SouthDirectionMovement(IRover rover) : base(rover)
    {
    }

    public override void MoveForward()
    {
        Rover.CoordinateY -= Rover.Speed;
    }

    public override void MoveLeft()
    {
        Rover.Direction = Direction.E;
    }

    public override void MoveRight()
    {
        Rover.Direction = Direction.W;
    }
}