using PackageTrack.Models;

namespace PackageTrack.Views;

public partial class ResultsPage : ContentPage
{
    public Package Package { get; set; }


    public ResultsPage(Package package)
    {
		InitializeComponent();
        Package = package;
        BindingContext = this;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}