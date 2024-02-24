﻿using AllPlay.Domain.ValueObjects.Common;
using NetTopologySuite.Geometries;

namespace AllPlay.Domain.Entities;

public class Area
{
    private readonly List<SportEvent> _sportEvents = new();
    
    public Id Id { get; }
    public string Name { get; }
    public string StreetAddress { get; }
    public string CountryRegion { get; }
    public string CountryIso { get; }
    public string PostalCode { get; }
    public string FormattedAddress { get; }
    
    public PhoneNumber PhoneNumber { get; }
    public bool IsOutdoorArea { get; }
    
    public Point Point { get; }
    public Polygon Polygon { get; }
    
    public AllPlay.Domain.ValueObjects.Coordinates Coordinates { get; }

    public IReadOnlyList<SportEvent> SportEvents => _sportEvents.AsReadOnly();

    public Area()
    {
        
    }
    
    public Area(
        Id id,
        string name,
        string streetAddress,
        string countryRegion,
        string countryIso,
        string postalCode,
        string formattedAddress,
        PhoneNumber phoneNumber,
        bool isOutdoorArea,
        Point point,
        Polygon polygon,
        AllPlay.Domain.ValueObjects.Coordinates coordinates)
    {
        Id = id;
        Name = name;
        StreetAddress = streetAddress;
        CountryRegion = countryRegion;
        CountryIso = countryIso;
        PostalCode = postalCode;
        FormattedAddress = formattedAddress;
        PhoneNumber = phoneNumber;
        IsOutdoorArea = isOutdoorArea;
        Point = point;
        Polygon = polygon;
        Coordinates = coordinates;
    }

    public void AddSportEvent(SportEvent sportEvent)
    {
        _sportEvents.Add(sportEvent);
    }
}