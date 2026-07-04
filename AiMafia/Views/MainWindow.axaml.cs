using System;
using AiMafia.Models;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AiMafia.Views;

public partial class MainWindow : Window
{
    public string key = "";
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
        key = APIKey.Text;
        if (key != string.Empty)
        {
            Console.WriteLine(key);
            AiClient.setKey(key);
            AiAnswer.Text = model.getRespose(UserInput.Text);
        }
    }
}