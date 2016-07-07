using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AsyncChatNew.Domain;

namespace AsyncChatNew.Repositories
{
    public class ChatUserRepository : IRepository<ChatUser>
    {
        public AsyncChatNewEntities Context { get; }

        public ChatUserRepository()
        {
            Context = new AsyncChatNewEntities();
        }

        public async Task<IEnumerable<ChatUser>> GetAllAsync()
        {
            return await Context.ChatUsers.ToListAsync();
        }

        public async Task<IEnumerable<ChatUser>> GetAllAsyncWithAspNetUser()
        {
            return await Context.ChatUsers.Include(n => n.AspNetUser).ToListAsync();
        }

        public async Task<IEnumerable<ChatUser>> GetAllAsyncWithDependents()
        {
            return await Context.ChatUsers.Include(n => n.Messages).Include(n => n.Incidents).ToListAsync();
        }

        public async Task<ChatUser> GetUserById(int id)
        {
            return await Context.ChatUsers.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<ChatUser> GetUserByIdWithAspNetUser(int id)
        {
            return await Context.ChatUsers.Include(n => n.AspNetUser).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<ChatUser> GetUserByIdWithDependents(int id)
        {
            return await Context.ChatUsers.Include(n => n.Messages).Include(n => n.Incidents).FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}