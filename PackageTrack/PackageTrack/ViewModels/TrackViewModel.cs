using PackageTrack.Models;
using PackageTrack.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PackageTrack.ViewModels;

public class TrackViewModel : BindableObject
{
    private string trackingCode;
    private bool isBusy;
    private Package? package;

    public string TrackingCode
    {
        get => trackingCode;
        set { trackingCode = value; OnPropertyChanged(); }
    }

    public bool IsBusy
    {
        get => isBusy;
        set { isBusy = value; OnPropertyChanged(); }
    }

    public Package? Package
    {
        get => package;
        set { package = value; OnPropertyChanged(); }
    }

    public ICommand SearchCommand { get; }

    private readonly PackageServices _service = new PackageServices();

    public TrackViewModel()
    {
        SearchCommand = new Command(async () => await FetchPackageInfoAsync(), () => !IsBusy);
    }

    // Implementação correta do método
    public async Task FetchPackageInfoAsync()
    {
        if (string.IsNullOrWhiteSpace(TrackingCode))
            return;

        IsBusy = true;
        Package = await _service.GetByCodeAsync(TrackingCode);
        IsBusy = false;
    }
}
