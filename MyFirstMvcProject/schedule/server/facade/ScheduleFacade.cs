
using schedule.server.entity;
using schedule.server.facade.dto;
using schedule.server.services.crud;

namespace schedule.server.facade
{
    public class ScheduleFacade(ContactCrudService contactCrudService)
    {
        readonly ContactCrudService _contactCrudService = contactCrudService;

        public Contact CreateContact(ContactDto dto)
        {
            return _contactCrudService.Create(FromDto(dto));
        }

        public ContactDto FindById(int id)
        {
            return FromEntity(_contactCrudService.FindById(id));
        }

        private ContactDto FromEntity(Contact contact)
        {
            return new ContactDto(
                contact.Name,
                contact.Phone,
                contact.Email
            );
        }
        private Contact FromDto(ContactDto dto)
        {
            return new Contact()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email
            };
        }
    }
}