using KacperKolos2.Context;


namespace KacperKolos2.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ApbdContext _context;

    public EventRepository(ApbdContext context)
    {
        _context = context;
    }
}