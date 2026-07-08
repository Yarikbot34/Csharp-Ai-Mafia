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
    
    private class resp
    {public List<OpenRouterModel> data; }
    public MainWindow()
    {
        InitializeComponent();
    }



    //Test function
    
    AiModel model = new AiModel
    {
        model = "nvidia/nemotron-3-ultra-550b-a55b:free"
    };
    
    public void getAnswer(object? sender, RoutedEventArgs e)
    {
        AiClient.apiKey = APIKey.Text;
        if (AiClient.apiKey != string.Empty)
        {
            Console.WriteLine(AiClient.apiKey);
            AiClient.setKey(AiClient.apiKey);
            AiAnswer.Text = model.getRespose(UserInput.Text);
        }
    }
}