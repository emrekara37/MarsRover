using Dawn;
using MarsRover.Domain.Extensions;
using MediatR;

namespace MarsRover.Domain.Commands;

public class CreatePlateauCommand : IRequest
{
    public CreatePlateauCommand(string surfaceAreaSize)
    {
        SurfaceAreaSize = Guard.Argument(surfaceAreaSize, nameof(surfaceAreaSize)).NotNullOrEmpty();
    }
    public string SurfaceAreaSize { get; set; }

   
}