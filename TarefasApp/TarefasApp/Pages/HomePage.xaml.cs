using TarefasApp.Models;
using TarefasApp.Services;
using TarefasApp.ViewModels;
// LEONARDO DE LIMA PEDROSO - CB3026655
namespace TarefasApp.Pages;

public partial class HomePage : ContentPage
{
    private readonly TaskViewModel _taskViewModel;

    public HomePage()
	{
		InitializeComponent();

        _taskViewModel = new TaskViewModel(App.TaskService);
        BindingContext = _taskViewModel;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        var addPage = new TaskAdd(_taskViewModel);
        await Navigation.PushModalAsync(new NavigationPage(addPage));
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var task = e.CurrentSelection[0] as TaskItem;
            ((CollectionView)sender).SelectedItem = null;

            if (task != null)
            {
                await Navigation.PushAsync(new TaskDetails(task, App.TaskService));
            }
        }
    }

    private async void OnCreditsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Credits());
    }
}