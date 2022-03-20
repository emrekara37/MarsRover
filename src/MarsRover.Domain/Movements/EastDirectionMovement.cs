using MarsRover.Domain.Contracts;
using MarsRover.Domain.Shared;

namespace MarsRover.Domain.Movements;

public sealed class EastDirectionMovement : RoverMovement
{
    public EastDirectionMovement(IRover rover) : base(rover)
    {
    }

    public override void MoveForward()
    {
        Rover.CoordinateX += Rover.Speed;
    }

    public override void MoveLeft()
    {
        Rover.Direction = Direction.N;
    }

    public override void MoveRight()
    {
        Rover.Direction = Direction.S;
    }
}