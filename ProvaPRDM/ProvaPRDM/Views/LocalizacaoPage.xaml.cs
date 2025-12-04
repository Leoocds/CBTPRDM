using Microsoft.Maui.Devices.Sensors;

namespace ProvaPRDM.Views;

public partial class LocalizacaoPage : ContentPage
{
    public LocalizacaoPage()
    {
        InitializeComponent();
    }

    private async void OnGetLocation(object sender, EventArgs e)
    {
        try
        {
            var local = await Geolocation.GetLastKnownLocationAsync();

            if (local == null)
                local = await Geolocation.GetLocationAsync(
                    new GeolocationRequest(GeolocationAccuracy.Medium));

            LocalLabel.Text = $"Latitude: {local.Latitude}\nLongitude: {local.Longitude}";
        }
        catch
        {
            LocalLabel.Text = "Erro ao obter localização!";
        }
    }
}
