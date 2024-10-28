namespace TaskManagerAPI.Application.Common.ExceptionsError;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
