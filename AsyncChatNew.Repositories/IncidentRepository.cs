using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AsyncChatNew.Domain;

namespace AsyncChatNew.Repositories
{
    public class IncidentRepository : IRepository<Incident>
    {
        public AsyncChatNewEntities Context { get; }

        public IncidentRepository()
        {
            Context = new AsyncChatNewEntities();
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await Context.Incidents.ToListAsync();
        }

        public async Task<IEnumerable<Incident>> GetAllAsyncWithDependents()
        {
            return await Context.Incidents.Include(n => n.Messages).ToListAsync();
        }

        public async Task<Incident> GetIncedentById(int id)
        {
            return await Context.Incidents.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Incident> GetIncedentByIdWithDependents(int id)
        {
            return await Context.Incidents.Include(n => n.Messages).FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}