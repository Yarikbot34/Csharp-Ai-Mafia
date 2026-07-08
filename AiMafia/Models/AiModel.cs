using System;
using OpenAI;
using OpenAI.Chat;
using AiMafia.Views;

namespace AiMafia.Models;

public class AiModel
{
    
    public string name;
    public OpenRouterModel model;


    public string getRespose(string message)
    {
        try
        {
            AiClient.AddUserMessage(message);
            ChatCompletion completion = AiClient.client.GetChatClient(model.url).CompleteChat(AiClient.messages);
            
            return $"\nОтвет: {completion.Content[0].Text}";
        }
        catch (Exception ex)
        {
            return $"Ошибка подключения: {ex.Message}";
        }
    }    
        
}