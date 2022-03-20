using MarsRover.Domain.Contracts;
using MarsRover.Domain.Movements;
using MarsRover.Domain.Shared;

namespace MarsRover.Domain;

public class MovementFactory
{
    public static RoverMovement CreateMovementByDirectionType(Direction direction, IRover rover)
    {
        return direction switch
        {
            Direction.E => new EastDirectionMovement(rover),
            Direction.N => new NorthRoverMovement(rover),
            Direction.S => new SouthDirectionMovement(rover),
            Direction.W => new WestDirectionMovement(rover),
            _ => throw new NotImplementedException()
        };
    }
}