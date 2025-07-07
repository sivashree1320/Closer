using Closer.Domain.Models;

namespace Closer.Domain.Interface
{
    public interface IContactMessageService
    {
        //Task<List<ContactMessage>> GetAllMessagesAsync();
        //Task<ContactMessage?> GetMessageByIdAsync(int id);
        //Task AddMessageAsync(ContactMessage message);
        //Task DeleteMessageAsync(int id);

        Task AddMessageAsync(ContactMessage contactMessage);
        
    }
}
