using MarsRover.Domain;
using MarsRover.Domain.Commands;
using MarsRover.Domain.Shared;
using MarsRover.Domain.Shared.Exceptions;
using MediatR;

namespace MarsRover.Application;

public class MovementCommandHandler : IRequestHandler<MovementCommand>
{
    private readonly PlateauContext _context;

    public MovementCommandHandler(PlateauContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(MovementCommand request, CancellationToken cancellationToken)
    {
        foreach (var move in request.Path)
        {
            if (!Enum.TryParse(typeof(Movement), move.ToString(), out var movement))
            {
                throw new InvalidRequestException();
            }

            _context.ActiveRover.Move((Movement)movement);
        }

        return Unit.Task;
    }
}