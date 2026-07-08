using System.Collections.Generic;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using AiMafia.Views;
using OpenAI;

namespace AiMafia.Models;

public static class AiClient
{
    public static string apiKey;
    
    public static async Task<bool> getModelList(string key = null)
    {
        if (key != null) apiKey = key;
        using HttpClient client = new HttpClient();
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://openrouter.ai/api/v1/models");
            request.Headers.Add("Authorization", $"Bearer {apiKey}");
            
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
    
    public static List<ChatMessage> messages = new List<ChatMessage>
    {
        ChatMessage.CreateSystemMessage("Отвечай максимально кратко"),
    };

    public static ApiKeyCredential key { get; set;}
    private static OpenAIClientOptions options = new OpenAIClientOptions { Endpoint = new Uri("https://openrouter.ai/api/v1")};
    public static OpenAIClient client;

    public static void setKey(string apiKey)
    {
        if (apiKey != null)
        {
            Console.WriteLine(apiKey);
            key = new ApiKeyCredential(apiKey);
            client = new OpenAIClient(key, options);
        }
    }
    
    public static void AddUserMessage(string message)
    {
        ChatMessage mess = ChatMessage.CreateUserMessage(message);
        messages.Add(mess);
    }
}