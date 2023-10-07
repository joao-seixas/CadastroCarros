using Negocio;

namespace Apresentacao
{
    public class Menus
    {
        public static int MenuPrincipal()
        {
            char tecla;

            Console.WriteLine("SISTEMA DE CADASTRO DE CARROS");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Consultar veículos;");
            Console.WriteLine("2 - Cadastrar veículos;");
            Console.WriteLine("3 - Sair.");

            do
            {
                tecla = Console.ReadKey(true).KeyChar;
            } while (tecla != '1' && tecla != '2' && tecla != '3');

            return (int)tecla - 48;
        }

        public static int MenuPersistencia()
        {
            char tecla;

            Console.WriteLine("ESCOLHA ONDE OS DADOS SERÃO PERSISTIDOS:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Memória");
            Console.WriteLine("2 - Arquivo");

            do
            {
                tecla = Console.ReadKey(true).KeyChar;
            } while (tecla != '1' && tecla != '2');

            return (int)tecla - 48;
        }

        public static Carros CadastrarCarro()
        {
            Carros carro = new Carros();

            Console.Write("Entre com a marca do carro: ");
            carro.Marca = Console.ReadLine();

            Console.Write("Entre com o modelo do carro: ");
            carro.Modelo = Console.ReadLine();

            Console.Write("Entre com a cor do carro: ");
            carro.Cor = Console.ReadLine();

            double cilindradas;
            do
            {
                Console.Write("Entre com as cilindradas do carro: ");
            } while (!double.TryParse(Console.ReadLine(), out cilindradas));
            carro.Cilindradas = cilindradas;

            int potencia;
            do
            {
                Console.Write("Entre com a potência (em HP) do carro: ");
            } while (!int.TryParse(Console.ReadLine(), out potencia));
            carro.Potencia = potencia;

            int ano;
            do
            {
                Console.Write("Entre com o ano de fabricação do carro: ");
            } while (!int.TryParse(Console.ReadLine(), out ano));
            carro.Ano = ano;

            DateTime dataVenda;
            do
            {
                Console.Write("Entre com a data de venda do do carro: ");
            } while (!DateTime.TryParse(Console.ReadLine(), out dataVenda));
            carro.DataVenda = dataVenda;

            return carro;
        }
        public static (int, string) BuscarCarro()
        {
            char tecla;
            string busca;

            Console.Clear();
            Console.WriteLine("CONSULTAR VEÍCULOS");
            Console.WriteLine("------------------");
            Console.WriteLine();
            Console.WriteLine("Escolha o campo a ser pesquisado:");
            Console.WriteLine();
            Console.WriteLine("1 - Buscar por marca;");
            Console.WriteLine("2 - Buscar por modelo;");
            Console.WriteLine("3 - Buscar por cor;");
            Console.WriteLine("4 - Buscar por cilindrada;");
            Console.WriteLine("5 - Buscar por potência;");
            Console.WriteLine("6 - Buscar por ano de fabricação;");
            Console.WriteLine("7 - Buscar por data de venda.");
            Console.WriteLine();
            Console.WriteLine("0 - VOLTAR");

            do
            {
                tecla = Console.ReadKey(true).KeyChar;
            } while ((int) tecla < 48 || (int) tecla > 55);

            if (tecla == '0') return (0, "");

            Console.WriteLine();
            Console.Write("Entre com o termo da busca: ");
            busca = Console.ReadLine();
            
            return ((int) tecla - 48, busca);
        }

        public static void ExibeCarro(Carros carro)
        {
            Console.WriteLine("Marca: " + carro.Marca);
            Console.WriteLine("Modelo: " + carro.Modelo);
            Console.WriteLine("Cor: " + carro.Cor);
            Console.WriteLine("Cilindradas: " + carro.Cilindradas.ToString("0.0"));
            Console.WriteLine("Potência: " + carro.Potencia + " cavalos");
            Console.WriteLine("Ano de fabricação: " + carro.Ano);
            Console.WriteLine("Data de venda: " + carro.DataVenda);
            Console.WriteLine("Vendido há " + Math.Floor((DateTime.Now - carro.DataVenda).TotalDays) + " dias");
            Console.WriteLine();
            Console.WriteLine("Id: " + carro.Id);
        }
        public static (Guid, char) ExibeCarros(List<Carros> carros)
        {
            char tecla;
            int carroAtual = 1;

            Console.Clear();
            Console.WriteLine(carros.Count + " registros encontrados!");
            Console.WriteLine();
            do
            {
                Console.Clear();
                ExibeCarro(carros[carroAtual - 1]);
                Console.WriteLine();
                Console.WriteLine("Registro " + carroAtual + " de " + carros.Count);
                Console.WriteLine();
                Console.WriteLine("(A)nterior - (P)róximo - (D)eletar - (M)odificar - (S)air");
                tecla = Console.ReadKey(true).KeyChar;
                if ((tecla == 'A' || tecla == 'a') && carroAtual > 1) carroAtual--;
                if ((tecla == 'P' || tecla == 'p') && carroAtual < carros.Count) carroAtual++;
                if (tecla == 'D' || tecla == 'd' || tecla == 'M' || tecla == 'm') return (carros[carroAtual - 1].Id, tecla);
            } while (tecla != 's' && tecla != 'S');
            Console.Clear();
            return (new Guid(), ' ');
        }

    }
}