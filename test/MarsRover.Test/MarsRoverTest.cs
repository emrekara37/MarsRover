using System.Threading.Tasks;
using MarsRover.Domain;
using MarsRover.Domain.Commands;
using MarsRover.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest : IClassFixture<TestStartupFixture>
    {
        private readonly ServiceProvider _serviceProvider;
        public MarsRoverTest(TestStartupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Theory]
        [InlineData(new string[] { "5 5", "1 2 N", "LMLMLMLMM" }, "1 3 N")]
        [InlineData(new string[] { "5 5", "3 3 E", "MMRMMRMRRM" }, "5 1 E")]
        public async Task ValidInput_Should_(string[] input, string expected)
        {

            var mediator = _serviceProvider.GetRequiredService<IMediator>();

            await mediator.Send(new CreatePlateauCommand(input[0]));
            await mediator.Send(new InitializeRoverCommand(input[1]));
            await mediator.Send(new MovementCommand(input[2]));

            var context = _serviceProvider.GetRequiredService<PlateauContext>();

            context.ActiveRover.ToString().ShouldBeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("5a 5a", "3b 3 E", "MMRMMRMRRM")]
        [InlineData("5a 5a", "3b 3 X", "MMRMMRMRRM")]
        [InlineData("5 5", "3 3 E", "MMRMMRMXRRM")]
        public async Task InValidInput_Should_Throw_InvalidRequestException(params string[] input)
        {
            var mediator = _serviceProvider.GetRequiredService<IMediator>();

            async Task SendCommands()
            {
                await mediator.Send(new CreatePlateauCommand(input[0]));
                await mediator.Send(new InitializeRoverCommand(input[1]));
                await mediator.Send(new MovementCommand(input[2]));
            }

            await Should.ThrowAsync<InvalidRequestException>(SendCommands);
        }

        [Theory]
        [InlineData("5 5", "15 3 E", "MMRMMRMRRM")]
        [InlineData("5 5", "3 3 E", "MMMMMMMMMMMMMMMMM")]
        public async Task OutOfBoundInput_Should_Throw_OutOfBoundException(params string[] input)
        {
            var mediator = _serviceProvider.GetRequiredService<IMediator>();

            async Task SendCommands()
            {
                await mediator.Send(new CreatePlateauCommand(input[0]));
                await mediator.Send(new InitializeRoverCommand(input[1]));
                await mediator.Send(new MovementCommand(input[2]));
            }

            await Should.ThrowAsync<RoverOutOfBoundsException>(SendCommands);
        }
    }
}