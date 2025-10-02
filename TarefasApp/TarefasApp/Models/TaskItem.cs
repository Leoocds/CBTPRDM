using System;
using System.ComponentModel;

namespace TarefasApp.Models;

public class TaskItem : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string _title;
    private string _description;
    private DateTime _createdAt;
    private int _priority;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title
    {
        get => _title;
        set { _title = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title))); }
    }

    public string Description
    {
        get => _description;
        set { _description = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description))); }
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set { _createdAt = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CreatedAt))); }
    }

    public int Priority
    {
        get => _priority;
        set { _priority = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Priority))); }
    }

    public string PriorityText => Priority switch
    {
        1 => "Baixa",
        2 => "Média",
        3 => "Alta",
        _ => "Média",
    };
}
