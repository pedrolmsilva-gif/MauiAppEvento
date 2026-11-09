namespace MauiAppEvento.Models
{
    public class Evento
    {
        public string Nome { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime DataTermino { get; set; } = DateTime.Now.AddDays(1);
        public int QntParticipantes { get; set; }
        public double CustoParticipante { get; set; }

        // Calcula a duração em dias usando TimeSpan
        public int DuracaoEmDias
        {
            get => DataTermino.Subtract(DataInicio).Days;
        }

        // Calcula o custo total do evento
        public double CustoTotal
        {
            get => QntParticipantes * CustoParticipante;
        }
    }
}