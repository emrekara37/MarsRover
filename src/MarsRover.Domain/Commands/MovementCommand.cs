using Dawn;
using MarsRover.Domain.Extensions;
using MediatR;

namespace MarsRover.Domain.Commands;

public class MovementCommand : IRequest
{
    public MovementCommand(string path)
    {
        Path = Guard.Argument(path, nameof(path)).NotNullOrEmpty(); ;
    }

    public string Path { get; set; }
}