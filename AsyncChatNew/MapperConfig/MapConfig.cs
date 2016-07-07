using AutoMapper;

namespace AsyncChatNew.MapperConfig
{
    public abstract class MapConfig<TEntity, TModel> : IMapConfig
    {
        protected abstract void MapToEntity(IMappingExpression<TModel, TEntity> map);

        protected abstract void MapToModel(IMappingExpression<TEntity, TModel> map);

        public void ConfigMapToSourse()
        {
            AutoMapper.Mapper.Initialize(n => n.CreateMap<TModel, TEntity> ());
        }

        public void ConfigMapToDestination()
        {
            AutoMapper.Mapper.Initialize(n => n.CreateMap<TEntity, TModel>());
        }
    }
}