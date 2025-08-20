using common.services.crud;
using Microsoft.AspNetCore.Mvc;

namespace common.api
{
    
    public class AbstractEndpointCrudMapper<TDto, TEntity, TService>(string endpointBase): ICrudEndpointsMapper
        where TDto : class
        where TEntity : class
        where TService : ICrudDtoService<TDto,TEntity>
    {
        public void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler
        {
            app.MapPost(endpointBase,
                ([FromBody] TDto dto, TService service) =>
                {
                    TDto newDto = service.Create(dto);
                    return Results.Created($"{endpointBase}/{{id}}", newDto);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");
        }
    }
}