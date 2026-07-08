using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using AiMafia.Models;
using AiMafia.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AiMafia.Views;


public partial class MainWindow : Window
{
    ObservableCollection<OpenRouterModel> ViewAiModels { get; } = new ObservableCollection<OpenRouterModel>() ;
    public MainWindow()
    {
        InitializeComponent();
        LoadModels();
        DataContext = new MainWindowViewModel();
    }
    
    private void LoadModels()
    {
        
        var modelList = OpenRouterModel.GetModelList();
            
        foreach (var model in modelList)
        {
            ViewAiModels.Add(model);
        }

        ModelComboBox.ItemsSource = ViewAiModels;
            
        if (ViewAiModels.Count > 0)
            ModelComboBox.SelectedIndex = 0;
    }



    //Test function
    
    AiModel model = new AiModel
    {
        model = "nvidia/nemotron-3-ultra-550b-a55b:free"
    };
    
    public void getAnswer(object? sender, RoutedEventArgs e)
    {
        if (AiClient.apiKey != string.Empty)
        {
            Console.WriteLine(AiClient.apiKey);
            AiClient.setKey(AiClient.apiKey);
            AiAnswer.Text = model.getRespose(UserInput.Text);
        }
    }
}