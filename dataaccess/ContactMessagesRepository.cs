using Closer.Data;
using Closer.Domain.Interface;
using Closer.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Closer.dataaccess
{
    public class ContactMessagesRepository : IContactMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactMessagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(ContactMessage message)
        {
            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message != null)
            {
                _context.ContactMessages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ContactMessage>> GetAllMessagesAsync()
        {
            return await _context.ContactMessages.ToListAsync();
        }

        public async Task<ContactMessage?> GetMessageByIdAsync(int id)
        {
            return await _context.ContactMessages.FindAsync(id);
        }
    }
}
