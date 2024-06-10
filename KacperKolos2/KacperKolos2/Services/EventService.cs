using KacperKolos2.Repositories;
using PharmacyApi.Services;

namespace KacperKolos2.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
}