using System.Text.Json.Serialization;

namespace TestVoitures.Models;

public class Vehicule
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("marque")]
    public string Marque { get; set; } = string.Empty;

    [JsonPropertyName("modele")]
    public string Modele { get; set; } = string.Empty;

    [JsonPropertyName("annee")]
    public int Annee { get; set; }

    [JsonPropertyName("kilometrage")]
    public int Kilometrage { get; set; }
}
