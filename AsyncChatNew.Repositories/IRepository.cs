using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncChatNew.Domain;

namespace AsyncChatNew.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        AsyncChatNewEntities Context { get; }

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
