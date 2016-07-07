using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;

namespace AsyncChatNew.MapperConfig
{
    public static class AutoMapperHelper
    {
        public static void RegisterMappings()
        {
            var potencialConfig = Assembly.GetCallingAssembly().GetTypes()
                                          .Where(n => !n.IsAbstract && n.IsClass && typeof(IMapConfig)
                                          .IsAssignableFrom(n));
            foreach (var config in potencialConfig.Select(type => (IMapConfig)IoC.Instance.Get(type)))
            {
                config.ConfigMapToDestination();
                config.ConfigMapToSourse();
            }
        }

        /// <summary>
        /// Маппинг в сущность
        /// </summary>
        public static TU MapTo<T, TU>(this T from, TU toEntity)
        {
            AutoMapper.Mapper.Map(from, toEntity);
            return toEntity;
        }

        /// <summary>
        /// Маппинг колекции
        /// </summary>
        public static IEnumerable<TU> Select<T, TU>(this IEnumerable<T> from, TU obj)
            where TU : new()
        {
            return from.Select(n => n.MapTo(new TU()));
        }
    }
}