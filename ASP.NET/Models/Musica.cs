using System.Text.Json.Serialization;

namespace Api.Models;

public class Musica
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int AnoLancamento { get; set; }
    [JsonIgnore]
    public Artista? Artista { get; set; }
}