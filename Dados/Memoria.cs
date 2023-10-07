using Negocio;
using System.IO;
using System.Text.Json;

namespace Dados
{
    public class Memoria : ICarro
    {
        private readonly List<Carros> carros = new List<Carros>();
        public Carros GetById(Guid id)
        {
            return carros.FirstOrDefault(carro => carro.Id == id);
        }

        public List<Carros> GetByMarca(string marca)
        {
            return carros.FindAll(carro => carro.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase));
        }
        public List<Carros> GetByModelo(string modelo)
        {
            return carros.FindAll(carro => carro.Modelo.Contains(modelo, StringComparison.OrdinalIgnoreCase));
        }
        public List<Carros> GetByCor(string cor)
        {
            return carros.FindAll(carro => carro.Cor.Contains(cor, StringComparison.OrdinalIgnoreCase));
        }
        public List<Carros> GetByCilindradas(double cilindradas)
        {
            return carros.FindAll(carro => carro.Cilindradas == cilindradas);
        }
        public List<Carros> GetByPotencia(int potencia)
        {
            return carros.FindAll(carro => carro.Potencia == potencia);
        }
        public List<Carros> GetByAno(int ano)
        {
            return carros.FindAll(carro => carro.Ano == ano);
        }
        public List<Carros> GetByDataVenda(DateTime dataVenda)
        {
            return carros.FindAll(carro => carro.DataVenda == dataVenda);
        }
        public List<Carros> GetLastFive()
        {
            List<Carros> cincoCarros = new List<Carros>();

            if (carros.Count > 0)
            {
                for (int indice = 0; indice < 5 && indice < carros.Count; indice++)
                {
                    cincoCarros.Add(carros[indice]);
                }
            }

            return cincoCarros;
        }

        public void AdicionarCarro(Carros carro)
        {
            carros.Add(carro);
        }

        public void AtualizarCarro(Carros carro)
        {
            carros.Add(carro);
        }

        public void ExcluirCarro(Carros carro)
        {
            carros.Remove(carro);
        }
    }
}