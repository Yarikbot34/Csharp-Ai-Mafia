using System;
using AiMafia.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AiMafia.Views;

public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
    }

    public async void OnContinueClick(object? sender, RoutedEventArgs e)
    {
        string result = await AiClient.getModelList();
        switch (result)
        {
            case "ok":
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
                break;
            case "NullReferenceException":
                ErrorTextBlock.Text = "Ошибка получения кода";
                break;
        }
        
        
    }
}