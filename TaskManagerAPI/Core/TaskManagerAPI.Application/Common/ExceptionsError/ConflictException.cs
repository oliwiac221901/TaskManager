namespace TaskManagerAPI.Application.Common.ExceptionsError;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}
