﻿using System.Collections.Generic;
using System.Linq;
using AllPlay.Domain.Common.Exceptions;

namespace AllPlay.Domain.Entities.Map.ValueObjects;

public record SportType
{

    public string Sport { get; }

    private static readonly IReadOnlyList<string> ValidSportTypes = new List<string>
    {
        "basketball"
    };

    private SportType(string sport)
    {
        if (ValidSportTypes.Any(sportType => sportType.Equals(sport)))
        {
            throw new InvalidSportTypeException();
        }
        
        Sport = sport;
    }

}
