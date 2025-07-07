using Closer.Domain.Models;
using Closer.Domain.Interface;


namespace Closer.Service
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public ContactMessageService(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task AddMessageAsync(ContactMessage contactMessage)
        {
            _contactMessageRepository.AddMessageAsync(contactMessage);
            
        }
    }
}
