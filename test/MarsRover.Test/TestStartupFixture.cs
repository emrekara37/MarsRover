using MarsRover.Application;
using MarsRover.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Test;

public class TestStartupFixture
{
    public ServiceProvider ServiceProvider { get; }
    public TestStartupFixture()
    {

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMediatR(typeof(CreatePlateauCommandHandler).Assembly);

        serviceCollection.AddSingleton(typeof(PlateauContext));

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}