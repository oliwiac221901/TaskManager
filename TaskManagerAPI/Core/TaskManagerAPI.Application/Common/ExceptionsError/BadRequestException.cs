namespace TaskManagerAPI.Application.Common.ExceptionsError;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}
