using MarsRover.Domain.Contracts;

namespace MarsRover.Domain.Movements;

public abstract class RoverMovement
{
    protected RoverMovement(IRover rover)
    {
        Rover = rover;
    }

    public IRover Rover { get; }
    public abstract void MoveForward();
    public abstract void MoveLeft();
    public abstract void MoveRight();
}