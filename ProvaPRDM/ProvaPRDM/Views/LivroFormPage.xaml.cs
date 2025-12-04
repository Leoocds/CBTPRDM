using ProvaPRDM.Data;
using ProvaPRDM.Models;

namespace ProvaPRDM.Views;

public partial class LivroFormPage : ContentPage
{
    private Livro _livro;
    private readonly Database _db;

    public LivroFormPage(Database db, Livro livro = null)
	{
		InitializeComponent();
        _db = db;
        _livro = livro;

        if (_livro != null)
        {
            NomeEntry.Text = livro.Nome;
            AutorEntry.Text = livro.Autor;
            EmailEntry.Text = livro.EmailAutor;
            IsbnEntry.Text = livro.ISBN;
        }
        else
        {
            ExcluirBtn.IsVisible = false;
        }
    }

    private async void OnSalvar(object sender, EventArgs e)
    {
        if (_livro == null)
            _livro = new Livro();

        _livro.Nome = NomeEntry.Text;
        _livro.Autor = AutorEntry.Text;
        _livro.EmailAutor = EmailEntry.Text;
        _livro.ISBN = IsbnEntry.Text;

        await _db.SaveLivroAsync(_livro);
        await Navigation.PopAsync();
    }

    private async void OnExcluir(object sender, EventArgs e)
    {
        if (_livro != null)
            await _db.DeleteLivroAsync(_livro);

        await Navigation.PopAsync();
    }
}
