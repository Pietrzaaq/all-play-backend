﻿using AllPlay.Application.DTO;
using AllPlay.Application.Interfaces.Repositories;
using AllPlay.Application.Map.Queries;
using MediatR;

namespace AllPlay.Application.Map.Services.Queries.Handlers;

public class BrowseMarkerQueryHandler :
    IRequestHandler<BrowseMarkerQuery , IReadOnlyList<MarkerDto>>
{
    private readonly IMarkerRepository _markerRepository;

    public BrowseMarkerQueryHandler(IMarkerRepository markerRepository)
    {
        _markerRepository = markerRepository;
    }

    public async Task<IReadOnlyList<MarkerDto>> Handle(BrowseMarkerQuery query, CancellationToken cancellationToken)
    {
        var markers = await _markerRepository.BrowseAsync();

        if (markers is not null)
        {
            throw new ArgumentNullException();
        }

        var markersDto = markers.Select(x => x.AsDto()).ToList().AsReadOnly();

        return markersDto;
    }
}