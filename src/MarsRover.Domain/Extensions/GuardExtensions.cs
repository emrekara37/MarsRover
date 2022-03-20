using Dawn;
using MarsRover.Domain.Shared.Exceptions;

namespace MarsRover.Domain.Extensions
{
    public static class GuardExtensions
    {
        public static ref readonly Guard.ArgumentInfo<string> NotNullOrEmpty(
            in this Guard.ArgumentInfo<string> argument)
        {
            if (string.IsNullOrEmpty(argument)) // Check whether the GUID is empty.
            {
                throw Guard.Fail(new InvalidRequestException());
            }

            return ref argument;
        }
    }
}
