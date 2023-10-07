using Negocio;
using System.Text.Json;

namespace Dados
{
    public class Arquivo : ICarro
    {
        private string caminhoJSON = @".\Carros.JSON";
        private string dadosJSON;
        private JsonSerializerOptions opcoes = new JsonSerializerOptions { WriteIndented = true };
        private readonly List<Carros> carros = new List<Carros>();
        public Arquivo()
        {
            if (File.Exists(caminhoJSON))
            {
                dadosJSON = File.ReadAllText(caminhoJSON);
                carros = JsonSerializer.Deserialize<List<Carros>>(dadosJSON, opcoes);
            }
        }
        
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
            File.WriteAllText(caminhoJSON, JsonSerializer.Serialize(carros, opcoes));
        }

        public void AtualizarCarro(Carros carro)
        {
            carros.Add(carro);
        }

        public void ExcluirCarro(Carros carro)
        {
            carros.Remove(carro);
            File.WriteAllText(caminhoJSON, JsonSerializer.Serialize(carros, opcoes));
        }
    }
}
