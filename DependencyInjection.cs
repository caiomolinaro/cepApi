using CepApi.Features.Cep;
using CepApi.Features.Cep.Services;

namespace CepApi;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ICepApiService, CepApiService>();

        services.AddRefitClient<ICepApi>()
        .ConfigureHttpClient((sp, c) =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var cepApiUrl = configuration.GetValue<string>("CepApi");
            c.BaseAddress = new Uri(cepApiUrl!);
        });

        return services;
    }
}
