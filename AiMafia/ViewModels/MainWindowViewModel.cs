using System.Collections.ObjectModel;
using AiMafia.Models;
using AiMafia.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AiMafia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public partial class PlayerRow : ObservableObject
    {
        [ObservableProperty]
        private int _playerNumber;

        [ObservableProperty]
        private OpenRouterModel _selectedModel;

        public PlayerRow(int number)
        {
            PlayerNumber = number;
        }
    }
}
