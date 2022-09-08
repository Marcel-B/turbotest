using com.marcelbenders.Aqua.Persistence;
using com.marcelbenders.Aqua.SqlServer.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace com.marcelbenders.Aqua.Application;

public static class ServiceExtension
{
    public static IServiceCollection AddAquaApplication(this IServiceCollection services) =>
        services
        .AddScoped<IAquariumRepository, AquariumRepository>()
        .AddScoped<IDuengungRepository, DuengungRepository>()
        .AddScoped<IFischRepository, FischRepository>()
        .AddScoped<IMessungRepository, MessungRepository>()
        .AddScoped<IPflanzeRepository, PflanzeRepository>()
        .AddScoped<IPflanzeRepository, PflanzeRepository>()
        .AddScoped<IKoralleRepository, KoralleRepository>()
        .AddScoped<INotizRepository, NotizRepository>()
        .AddMediatR(typeof(GetMessungenQueryHandler));

}