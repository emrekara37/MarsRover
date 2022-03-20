using MarsRover.Domain.Contracts;
using MarsRover.Domain.Extensions;
using MarsRover.Domain.Movements;
using MarsRover.Domain.Shared;
using MarsRover.Domain.Shared.Exceptions;

namespace MarsRover.Domain.Rovers;

public abstract class Rover : IRover
{
    protected Rover(int coordinateX, int coordinateY, Direction direction, IPlateau plateau)
    {
        Plateau = plateau;
        CoordinateX = coordinateX;
        CoordinateY = coordinateY;
        Direction = direction;
    }

    public abstract int Speed { get; }
    public abstract string Name { get; }
    public IPlateau Plateau { get; }
    public RoverMovement Movement { get; set; } = null!;

    private int _coordinateX;
    public int CoordinateX
    {
        get => _coordinateX;
        set
        {
            if (value > Plateau.CoordinateX || value < 0)
            {
                throw new RoverOutOfBoundsException();
            }
            _coordinateX = value;
        }
    }
    private int _coordinateY;
    public int CoordinateY
    {
        get => _coordinateY;
        set
        {
            if (value > Plateau.CoordinateY || value < 0)
            {
                throw new RoverOutOfBoundsException();
            }
            _coordinateY = value;
        }
    }
    private Direction _direction;
    public Direction Direction
    {
        get => _direction;
        set
        {
            _direction = value;
            Movement = MovementFactory.CreateMovementByDirectionType(Direction, this);
        }
    }

    public void Move(Movement movement)
    {
        switch (movement)
        {
            case Shared.Movement.L:
                Movement.MoveLeft();
                break;
            case Shared.Movement.M:
                Movement.MoveForward();
                break;
            case Shared.Movement.R:
                Movement.MoveRight();
                break;
            case Shared.Movement.None:
            default:
                throw new NotImplementedException();
        }
    }
    public override string ToString()
    {
        return $"{CoordinateX} {CoordinateY} {Direction}";
    }
}