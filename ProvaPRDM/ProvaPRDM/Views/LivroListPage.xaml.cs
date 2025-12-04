using ProvaPRDM.Data;
using ProvaPRDM.Models;

namespace ProvaPRDM.Views;

public partial class LivroListPage : ContentPage
{
    private readonly Database _db;

    public LivroListPage(Database db)
    {
        InitializeComponent();
        _db = db;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        LivrosListView.ItemsSource = await _db.GetLivrosAsync();
    }

    private async void OnAddLivro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LivroFormPage(_db));
    }

    private async void OnLivroSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Livro livro)
            await Navigation.PushAsync(new LivroFormPage(_db, livro));
    }

    private async void OnLocalizacao(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LocalizacaoPage());
    }
}
