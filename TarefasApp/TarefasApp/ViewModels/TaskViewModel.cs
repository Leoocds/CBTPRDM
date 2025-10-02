using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TarefasApp.Models;
using TarefasApp.Services;

namespace TarefasApp.ViewModels;

public class TaskViewModel : INotifyPropertyChanged
{
    private readonly TaskService _service;

    // Lista exposta para bindings (CollectionView)
    public ObservableCollection<TaskItem> Tasks { get; private set; }

    // Propriedade para seleção (SelectedItem)
    private TaskItem _selectedTask;
    public TaskItem SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (_selectedTask != value)
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }
    }

    // Campos usados no modal de criação/edição (Title, Description, Priority)
    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set { if (_title != value) { _title = value; OnPropertyChanged(); } }
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set { if (_description != value) { _description = value; OnPropertyChanged(); } }
    }

    // Priority aqui é 0-based (0 = Baixa, 1 = Média, 2 = Alta).
    // Em TaskItem você pode armazenar 1..3 se preferir (ver onde cria o TaskItem).
    private int _priority = 1;
    public int Priority
    {
        get => _priority;
        set { if (_priority != value) { _priority = value; OnPropertyChanged(); } }
    }

    // Construtor padrão: cria um TaskService interno (útil para testes)
    public TaskViewModel() : this(new TaskService()) { }

    // Construtor que recebe o serviço (compatível com App.TaskService)
    public TaskViewModel(TaskService service)
    {
        _service = service ?? new TaskService();
        Tasks = _service.Tasks ?? new ObservableCollection<TaskItem>();

        // valores iniciais amigáveis
        Priority = 1;
        Title = string.Empty;
        Description = string.Empty;
    }

    // Adiciona task (usado em TaskAdd.xaml.cs)
    public void AddTask(TaskItem task)
    {
        if (task == null) return;

        // garante que seja adicionado no serviço e na coleção exposta
        _service.Add(task);
        if (!Tasks.Contains(task))
            Tasks.Add(task);
    }

    // Remove task (usado em TaskDetails)
    public void RemoveTask(TaskItem task)
    {
        if (task == null) return;

        _service.Remove(task);
        if (Tasks.Contains(task))
            Tasks.Remove(task);
    }

    // Atualiza (caso precise replicar mudanças já vinculadas via binding)
    public void UpdateTask(TaskItem task)
    {
        // como TaskItem implementa INotifyPropertyChanged, normalmente não é necessário
        // algo aqui; deixo o método pronto caso queira lógica extra.
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    #endregion
}
