using MarsRover.Domain;
using MarsRover.Domain.Commands;
using MarsRover.Domain.Shared.Exceptions;
using MediatR;

namespace MarsRover.Application;
public class CreatePlateauCommandHandler : IRequestHandler<CreatePlateauCommand>
{
    private readonly PlateauContext _context;

    public CreatePlateauCommandHandler(PlateauContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(CreatePlateauCommand request, CancellationToken cancellationToken)
    {
        var grid = request.SurfaceAreaSize.Split(" ");
        int coordinateX= 0;
        int coordinateY = 0;
        if (grid.Length != 2 || 
            !int.TryParse(grid[0], out coordinateX) || 
            !int.TryParse(grid[1], out coordinateY)) new InvalidRequestException();

        var marsPlateau = new MarsPlateau(coordinateX, coordinateY);

        _context.Initialize(marsPlateau);

        return Unit.Task;
    }
}