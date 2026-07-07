using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using AiMafia.Models;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AiMafia.Views;


public partial class MainWindow : Window
{
    public string key = "";
    
    private class resp
    {public List<OpenRouterModel> data; }
    public MainWindow()
    {
        InitializeComponent();
    }

    public async Task<string> getModelList()
    {
        using HttpClient client = new HttpClient();
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://openrouter.ai/api/v1/models?category=roleplay");
            request.Headers.Add("Authorization", $"Bearer {key}");
            var answ = await client.SendAsync(request);
            var responseBody = await answ.Content.ReadAsStringAsync();
            var rootNode = JsonNode.Parse(responseBody);
            List<OpenRouterModel> data = rootNode["data"].Deserialize<List<OpenRouterModel>>();
            foreach(var item in data) Console.WriteLine(item.url);
            return responseBody;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return string.Empty;
        }
    }

    //Test function
    
    AiModel model = new AiModel
    {
        model = "nvidia/nemotron-3-ultra-550b-a55b:free"
    };
    
    public void getAnswer(object? sender, RoutedEventArgs e)
    {
        key = APIKey.Text;
        if (key != string.Empty)
        {
            Console.WriteLine(key);
            AiClient.setKey(key);
            AiAnswer.Text = model.getRespose(UserInput.Text);
        }
    }
}