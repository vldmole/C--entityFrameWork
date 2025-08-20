using common.services.crud;
using schedule.server.context;
using schedule.server.entity;

namespace schedule.server.services.crud
{
    public class ContactCrudService(ScheduleContext dbContext) : AbstractBasicCrudService<Contact, ScheduleContext>(dbContext) 
    {
    }
}