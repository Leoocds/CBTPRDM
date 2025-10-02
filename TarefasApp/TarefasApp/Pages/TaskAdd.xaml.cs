using TarefasApp.ViewModels;
using TarefasApp.Models;

namespace TarefasApp.Pages;

public partial class TaskAdd : ContentPage
{
    private readonly TaskViewModel _viewModel;

    public TaskAdd(TaskViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var newTask = new TaskItem
        {
            Title = _viewModel.Title,
            Description = _viewModel.Description,
            CreatedAt = DateTime.Now,
            Priority = _viewModel.Priority + 1
        };

        _viewModel.AddTask(newTask);
        await Navigation.PopModalAsync();
    }
}
