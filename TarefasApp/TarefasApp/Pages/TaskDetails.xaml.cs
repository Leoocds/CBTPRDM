using TarefasApp.Models;
using TarefasApp.Services;

namespace TarefasApp.Pages;

public partial class TaskDetails : ContentPage
{
    private readonly TaskItem _task;
    private readonly TaskService _service;

    public TaskDetails(TaskItem task, TaskService service)
    {
        InitializeComponent();
        _task = task;
        _service = service;
        BindingContext = _task;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TaskEdit(_task, _service));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        _service.Remove(_task);
        await Navigation.PopAsync();
    }
}
