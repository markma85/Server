namespace InnovateFuture.Api.Exceptions;

public class IFUnauthorizedException:Exception
{
    public IFUnauthorizedException(string message):base(message)
    {}
}