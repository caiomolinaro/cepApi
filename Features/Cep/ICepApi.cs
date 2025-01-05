using CepApi.Features.Cep.Models;

namespace CepApi.Features.Cep;

public interface ICepApi
{
    [Get("/{cep}")]
    Task<ApiResponse<CepOutput>> ReturnCepAsync(string cep);
}
