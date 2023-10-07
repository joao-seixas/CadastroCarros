using Negocio;

namespace Dados
{
    public interface ICarro
    {
        Carros GetById(Guid id);
        List<Carros> GetByMarca(string marca);
        List<Carros> GetByModelo(string modelo);
        List<Carros> GetByCor(string cor);
        List<Carros> GetByCilindradas(double cilindradas);
        List<Carros> GetByPotencia(int potencia);
        List<Carros> GetByAno(int ano);
        List<Carros> GetByDataVenda(DateTime dataVenda);
        List<Carros> GetLastFive();
        void AdicionarCarro(Carros carro);
        void AtualizarCarro(Carros carro);
        void ExcluirCarro(Carros carro);
    }
}