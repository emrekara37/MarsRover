namespace MarsRover.Domain.Shared.Exceptions;
public class RoverOutOfBoundsException : Exception
{

    public RoverOutOfBoundsException() : base("The Rover cannot be out of bounds of the plateau!")
    {
    }
}