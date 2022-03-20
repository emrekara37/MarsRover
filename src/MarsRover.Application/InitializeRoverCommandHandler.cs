using MarsRover.Domain;
using MarsRover.Domain.Commands;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Shared;
using MarsRover.Domain.Shared.Exceptions;
using MediatR;

namespace MarsRover.Application;

public class InitializeRoverCommandHandler : IRequestHandler<InitializeRoverCommand>
{
    private readonly PlateauContext _context;

    public InitializeRoverCommandHandler(PlateauContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(InitializeRoverCommand request, CancellationToken cancellationToken)
    {
        var roverInfo = request.Position
            .Split(" ");
        if (roverInfo.Length != 3 ||
            !int.TryParse(roverInfo[0], out var coordinateX) ||
            !int.TryParse(roverInfo[1], out var coordinateY) ||
            !Enum.TryParse(typeof(Direction), roverInfo[2], out var direction)
           ) throw new InvalidRequestException();

        var rover = new CuriosityRover(
            coordinateX, 
            coordinateY,
            (Direction)(direction),
            _context.Plateau
        );

        _context.DeployRover(rover);
        return Unit.Task;
    }
}