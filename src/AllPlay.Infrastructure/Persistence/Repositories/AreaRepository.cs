﻿using AllPlay.Application.Abstractions.Repositories;
using AllPlay.Domain.Entities;
using AllPlay.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AllPlay.Infrastructure.Persistence.Repositories;

public class AreaRepository : IAreaRepository
{
    private readonly AllPlayDbContext _context;
    private readonly DbSet<Area> _areas;

    public AreaRepository(AllPlayDbContext context)
    {
        _context = context;
        _areas = context.Areas;
    }

    public async Task<Area> GetAsync(Guid id) =>
        await _areas.FirstOrDefaultAsync(x => x.Id == id);

    //TODO - Resolve problem with empty sport events collection
    public async Task<IReadOnlyList<Area>> BrowseAsync()
        => await _areas
            .Include(x => x.SportEvents)
            .ThenInclude(y => y.Players)
            .ToListAsync();

    public async Task<bool> ExistsAsync(Guid id) =>
        await _areas.AnyAsync(x => x.Id == id);

    //TODO - Implement real map browsing
    public async Task<bool> ExistsAsync(Coordinates coordinates)
    {
        return await _areas.AnyAsync(x => true);
    }

    public async Task AddAsync(Area area)
    {
        await _areas.AddAsync(area);
        await _context.SaveChangesAsync();
    }
}