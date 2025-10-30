using PackageTrack.ViewModels;
using PackageTrack.Models;

namespace PackageTrack.Views;

public partial class HomePage : ContentPage
{

    private TrackViewModel _viewModel;

    public HomePage()
	{
		InitializeComponent();
        _viewModel = new TrackViewModel();
        BindingContext = _viewModel;
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_viewModel.TrackingCode))
        {
            await DisplayAlert("Erro", "Insira um c�digo de rastreamento v�lido.", "OK");
            return;
        }

        await _viewModel.FetchPackageInfoAsync();

        if (_viewModel.Package != null)
        {
            await Navigation.PushAsync(new ResultsPage(_viewModel.Package));
        }
        else
        {
            await DisplayAlert("Erro", "C�digo de rastreio n�o encontrado.", "OK");
        }
    }
}