namespace common.api
{
    public interface IEndpointMapper
    {
        public static
        abstract void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler;
    }
}