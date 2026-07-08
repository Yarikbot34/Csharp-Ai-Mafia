using System.Collections.ObjectModel;
using AiMafia.Models;
using AiMafia.Views;
namespace AiMafia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    ObservableCollection<OpenRouterModel> ViewAiModels { get; } = new ObservableCollection<OpenRouterModel>() ;
}