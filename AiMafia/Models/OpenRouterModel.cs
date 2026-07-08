using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AiMafia.Models;

public class OpenRouterModel
{
    private static List<OpenRouterModel> models = new List<OpenRouterModel>{};
    
    public async Task<bool> getModelList()
    {
        using HttpClient client = new HttpClient();
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://openrouter.ai/api/v1/models?category=roleplay");
            request.Headers.Add("Authorization", $"Bearer {AiClient.apiKey}");
            var answ = await client.SendAsync(request);
            var responseBody = await answ.Content.ReadAsStringAsync();
            var rootNode = JsonNode.Parse(responseBody);
            OpenRouterModel.SetModelList( rootNode["data"].Deserialize<List<OpenRouterModel>>());
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
    
    

    public static void SetModelList(List<OpenRouterModel> models) { OpenRouterModel.models = models; }

    public static List<OpenRouterModel> GetModelList() { return models;}
    
    [JsonPropertyName("id")] 
    public string url {get; set;}
    public string description;
}