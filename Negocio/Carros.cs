namespace Negocio
{
    public class Carros
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public double Cilindradas { get; set; }
        public int Potencia { get; set; }
        public int Ano { get; set; }
        public DateTime DataVenda { get; set; }

        public Carros()
        {
            Id = Guid.NewGuid();
        }
    }
}