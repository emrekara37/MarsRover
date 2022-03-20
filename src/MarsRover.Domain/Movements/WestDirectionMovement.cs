using MarsRover.Domain.Contracts;
using MarsRover.Domain.Extensions;
using MarsRover.Domain.Shared;

namespace MarsRover.Domain.Movements;

public sealed class WestDirectionMovement : RoverMovement
{
    public WestDirectionMovement(IRover rover) : base(rover)
    {
    }

    public override void MoveForward()
    {
        Rover.CoordinateX -= Rover.Speed;
    }

    public override void MoveLeft()
    {
        Rover.Direction = Direction.S;
    }

    public override void MoveRight()
    {
        Rover.Direction = Direction.N;
    }
}