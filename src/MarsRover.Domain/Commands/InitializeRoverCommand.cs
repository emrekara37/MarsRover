using Dawn;
using MarsRover.Domain.Extensions;
using MediatR;

namespace MarsRover.Domain.Commands;

public class InitializeRoverCommand : IRequest
{
    public InitializeRoverCommand(string position)
    {
        Position = Guard.Argument(position, nameof(position)).NotNullOrEmpty();
    }
    public string Position { get; set; }

}