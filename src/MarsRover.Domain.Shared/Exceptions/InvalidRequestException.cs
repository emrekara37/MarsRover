namespace MarsRover.Domain.Shared.Exceptions;

public class InvalidRequestException : Exception
{

    public InvalidRequestException() : base("The request input contains invalid arguments!")
    {
    }
}