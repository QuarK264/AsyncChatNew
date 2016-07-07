using AsyncChatNew.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AsyncChatNew.Repositories
{
    public class AttachmentRepository : IRepository<Attachment>
    {
        public AsyncChatNewEntities Context { get; }

        public AttachmentRepository()
        {
            Context = new AsyncChatNewEntities();
        }

        public async Task<IEnumerable<Attachment>> GetAllAsync()
        {
            return await Context.Attachments.ToListAsync();
        }

        public async Task<Attachment> GetAttachmentById(int id)
        {
            return await Context.Attachments.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Attachment> GetAttachmentByIdWithMessage(int id)
        {
            return await Context.Attachments.Include(n => n.Message).FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}