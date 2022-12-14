using AllPlay.Domain.ValueObjects;

namespace AllPlay.Domain.Entities;

public sealed class SportEvent
{
    private readonly List<Player> _players = new ();
    
    public Guid Id { get; }
    public Guid AreaId { get; }
    public SportType SportType { get; }
    public string CreatedBy { get; }
    public DateTime CreationDate { get; }
    public DateTime EventStartDate { get; }
    public DateTime EventEndDate { get; }
    public Area Area { get; set; }
    public IReadOnlyList<Player> Players => _players.AsReadOnly();

    public SportEvent()
    {
        
    }
    
    private SportEvent(
        Guid id,
        Guid areaId,
        SportType sportType,
        string createdBy,
        DateTime creationDate, 
        DateTime eventStartDate,
        DateTime eventEndDate)
    {
        Id = id;
        AreaId = areaId;
        SportType = sportType;
        CreatedBy = createdBy;
        CreationDate = creationDate;
        EventStartDate = eventStartDate;
        EventEndDate = eventEndDate;
    }

    public static SportEvent Create(
        Guid id,
        Guid areaId,
        SportType sportType,
        string createdBy,
        DateTime creationDate, 
        DateTime eventStartDate,
        DateTime eventEndDate)
    {
        return new(
            id,
            areaId,
            sportType,
            createdBy,
            creationDate, 
            eventStartDate,
            eventEndDate
        );
    }
}
