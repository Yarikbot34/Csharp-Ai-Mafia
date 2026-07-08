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
    

    public static void SetModelList(List<OpenRouterModel> models) { OpenRouterModel.models = models; }

    public static List<OpenRouterModel> GetModelList() { return models;}
    
    [JsonPropertyName("id")] 
    public string url {get; set;}
    public string description;
}