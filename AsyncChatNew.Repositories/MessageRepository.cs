using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AsyncChatNew.Domain;

namespace AsyncChatNew.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        public AsyncChatNewEntities Context { get; }

        public MessageRepository()
        {
            Context = new AsyncChatNewEntities();
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await Context.Messages.ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetAllAsyncWithDependets()
        {
            return await Context.Messages.Include(n => n.Attachments).ToListAsync();
        }

        public async Task<Message> GetMessageById(long id)
        {
            return await Context.Messages.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Message> GetMessageByIdWithDependents(long id)
        {
            return await Context.Messages.Include(n => n.Attachments).FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}