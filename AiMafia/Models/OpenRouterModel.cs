using System.Text.Json.Serialization;

namespace AiMafia.Models;

public class OpenRouterModel
{
    [JsonPropertyName("id")] 
    public string url {get; set;}
    public string description;
}