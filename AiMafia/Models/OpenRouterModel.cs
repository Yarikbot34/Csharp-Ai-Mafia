using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace AiMafia.Models;

public class OpenRouterModel
{
    private static List<OpenRouterModel> models = new List<OpenRouterModel>{};
    

    public static void SetModelList(List<OpenRouterModel> models) { OpenRouterModel.models = models; }
    
    public static List<OpenRouterModel> GetModelList() { return models;}
    
    [JsonPropertyName("id")] 
    public string url {get; set;}
    public string description {get; set;}
}