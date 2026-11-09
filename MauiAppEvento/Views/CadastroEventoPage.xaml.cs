using MauiAppEvento.Models;

namespace MauiAppEvento.Views;

public partial class CadastroEventoPage : ContentPage
{
    public CadastroEventoPage()
    {
        InitializeComponent();

        dtpck_inicio.Date = DateTime.Now;
        dtpck_termino.Date = DateTime.Now.AddDays(1);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_nome.Text))
            {
                await DisplayAlert("Atenção", "Por favor, preencha o nome do evento.", "OK");
                return;
            }

            if (dtpck_termino.Date < dtpck_inicio.Date)
            {
                await DisplayAlert("Data Inválida", "A data de término não pode ser anterior à data de início.", "OK");
                return;
            }

            if (!double.TryParse(txt_custo.Text, out double custoPorParticipante))
            {
                await DisplayAlert("Custo Inválido", "Informe um valor numérico válido para o custo por participante.", "OK");
                return;
            }

            Evento evento = new Evento
            {
                Nome = txt_nome.Text,
                Local = txt_local.Text,
                DataInicio = dtpck_inicio.Date.GetValueOrDefault(),
                DataTermino = dtpck_termino.Date.GetValueOrDefault(),
                QntParticipantes = Convert.ToInt32(stp_participantes.Value),
                CustoParticipante = custoPorParticipante
            };

            await Navigation.PushAsync(new ResumoEventoPage()
            {
                BindingContext = evento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}