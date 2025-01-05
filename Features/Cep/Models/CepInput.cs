namespace CepApi.Features.Cep.Models;

public class CepInput
{
    [Required]
    [RegularExpression(@"^\d+$")]
    public string? Cep { get; set; }
}
