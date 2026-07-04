using System.Collections.Generic;
using OpenAI.Chat;
using System;
using System.ClientModel;
using AiMafia.Views;
using OpenAI;

namespace AiMafia.Models;

public static class AiClient
{
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