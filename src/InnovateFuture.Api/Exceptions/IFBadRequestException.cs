namespace InnovateFuture.Api.Exceptions;

public class IFBadRequestException:Exception
{
    public IFBadRequestException(string message) : base(message)
    {
    }
}