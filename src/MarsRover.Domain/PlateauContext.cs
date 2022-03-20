using MarsRover.Domain.Contracts;

namespace MarsRover.Domain;

public class PlateauContext
{
    public IPlateau Plateau { get; private set; }
    public IRover ActiveRover { get; set; }

    public void Initialize(IPlateau plateau)
    {
        Plateau = plateau;
    }

    public void DeployRover(IRover rover)
    {
        ActiveRover = rover;
    }
}