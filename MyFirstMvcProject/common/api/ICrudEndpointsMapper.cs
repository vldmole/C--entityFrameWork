namespace common.api
{
    public interface ICrudEndpointsMapper
    {
        abstract void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler;
    }
}