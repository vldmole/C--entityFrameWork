
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

        private static Contact FromDto(ContactDto dto)
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