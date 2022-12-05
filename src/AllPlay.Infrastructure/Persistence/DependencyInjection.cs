﻿using AllPlay.Application.Interfaces.Repositories;
using AllPlay.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllPlay.Infrastructure.Persistence;

internal static class DependencyInjection
{

    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration[$"Database:ConnectionString"];
        services.AddSqlServer<AllPlayDbContext>(connectionString);
        services.AddScoped<IMarkerRepository, MarkerRepository>();
        services.AddScoped<IAreaRepository, AreaRepository>();

        return services;
    }
}