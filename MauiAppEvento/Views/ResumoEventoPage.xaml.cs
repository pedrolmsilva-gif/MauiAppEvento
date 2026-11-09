using MauiAppEvento.Models;

namespace MauiAppEvento.Views;

public partial class ResumoEventoPage : ContentPage
{
    public ResumoEventoPage()
    {
        InitializeComponent();
    }

    private async void Button_Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}