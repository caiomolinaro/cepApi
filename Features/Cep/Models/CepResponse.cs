namespace CepApi.Features.Cep.Models;

public class CepResponse
{
    public bool Success;
    public CepOutput? Data { get; set; }
    public string? ErrorMessage { get; set; }
}
