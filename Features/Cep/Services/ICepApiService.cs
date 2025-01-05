using CepApi.Features.Cep.Models;

namespace CepApi.Features.Cep.Services;

public interface ICepApiService
{
    Task<CepResponse> GetCepAsync(CepInput input);
}