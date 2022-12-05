﻿using AllPlay.Application.DTO;
using MediatR;

namespace AllPlay.Application.Map.Queries;

public record GetMarkerQuery(
    Guid Id) : IRequest<MarkerDto>;