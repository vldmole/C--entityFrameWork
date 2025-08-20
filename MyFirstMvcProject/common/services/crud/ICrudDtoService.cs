namespace common.services.crud
{
    public interface ICrudDtoService<TDto, TEntity> : IBasicCrudService<TEntity>
        where TDto : class
        where TEntity : class
    {
        TDto Create(TDto dto);
    }
}