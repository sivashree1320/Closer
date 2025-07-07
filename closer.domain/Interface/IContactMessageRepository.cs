
using Closer.Domain.Models;

namespace Closer.Domain.Interface
{
    public interface IContactMessageRepository
    {
        Task<List<ContactMessage>> GetAllMessagesAsync();
        Task<ContactMessage?> GetMessageByIdAsync(int id);
        Task AddMessageAsync(ContactMessage message);
        Task DeleteMessageAsync(int id);
    }
}
