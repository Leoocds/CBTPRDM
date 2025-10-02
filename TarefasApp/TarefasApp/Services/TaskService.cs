using System.Collections.ObjectModel;
using TarefasApp.Models;

namespace TarefasApp.Services;

public class TaskService
{
    public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

    public void Add(TaskItem task) => Tasks.Add(task);
    public void Remove(TaskItem task) => Tasks.Remove(task);
}
