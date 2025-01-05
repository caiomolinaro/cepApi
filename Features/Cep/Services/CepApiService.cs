using CepApi.Features.Cep.Models;

namespace CepApi.Features.Cep.Services;

public class CepApiService(ICepApi cepApi, ILogger<CepApiService> logger) : ICepApiService
{
    public async Task<CepResponse> GetCepAsync(CepInput input)
    {
        var response = await cepApi.ReturnCepAsync(input.Cep!);

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;

                logger.LogInformation($"CEP RETRIEVED WITH SUCCESS: {input.Cep}");

                return new CepResponse
                {
                    Success = true,
                    Data = content!,
                    ErrorMessage = null
                };
            }
        }

        catch (Exception ex)
        {
            logger.LogError($"ERROR RETRIEVING CEP: {input.Cep} - {ex.Message}");
        }

        return new CepResponse
        {
            Success = false,
            Data = null!,
            ErrorMessage = "CEP NOT FOUND"
        };
    }
}
