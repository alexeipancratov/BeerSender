using BeerSender.Domain.Boxes.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BeerSender.Domain;

public static class DomainExtensions
{
    public static void RegisterDomain(this IServiceCollection services)
    {
        services.AddScoped<CommandRouter>();
        
        services.AddTransient<CommandHandler<CreateBoxCommand>, CreateBoxCommandHandler>();
        services.AddTransient<CommandHandler<AddShippingLabelCommand>, AddShippingLabelCommandHandler>();
        services.AddTransient<CommandHandler<AddBeerBottleCommand>, AddBeerBottleCommandHandler>();
        services.AddTransient<CommandHandler<CloseBoxCommand>, CloseBoxCommandHandler>();
        services.AddTransient<CommandHandler<ShipBoxCommand>, ShipBoxCommandHandler>();
    }
}