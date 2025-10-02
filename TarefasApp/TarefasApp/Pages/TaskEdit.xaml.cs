using TarefasApp.Models;
using TarefasApp.Services;

namespace TarefasApp.Pages;

public partial class TaskEdit : ContentPage
{
    private readonly TaskItem _task;
    private readonly TaskService _service;

    public TaskEdit(TaskItem task, TaskService service)
    {
        InitializeComponent();
        _task = task;
        _service = service;
        BindingContext = _task;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
