using Apresentacao;
using Dados;
using Negocio;

ICarro repositorio;
repositorio = new Arquivo();
(int, string) busca;
(Guid, char) acao;

Console.Clear();
switch (Menus.MenuPersistencia())
{
    case 1:
        repositorio = new Memoria();
        break;

    case 2:
        repositorio = new Arquivo();
        break;
}

Console.Clear();
Console.WriteLine("Últimos 5 registros:");
Console.WriteLine();
List<Carros> cincoCarros = repositorio.GetLastFive();

if (cincoCarros.Count > 0)
{
    for (int indice = 0; indice < 5 && indice < cincoCarros.Count; indice++)
    {
        Console.WriteLine("Id: " + cincoCarros[indice].Id);
        Console.WriteLine("Marca: " + cincoCarros[indice].Marca);
        Console.WriteLine("Modelo: " + cincoCarros[indice].Modelo);
        Console.WriteLine();
    }
} else
{
    Console.WriteLine("Nenhum registro encontrado!");
    Console.WriteLine();
}

while (true)
    {
        switch (Menus.MenuPrincipal())
        {
            case 1:
                busca = Menus.BuscarCarro();
                acao = Menus.ExibeCarros(BuscaCarros(busca.Item1, busca.Item2));
                if (acao.Item2 == 'D' || acao.Item2 == 'd') DeletarCarro(acao.Item1);
                if (acao.Item2 == 'M' || acao.Item2 == 'm') EditarCarro(acao.Item1);
            break;

            case 2:
                repositorio.AdicionarCarro(Menus.CadastrarCarro());
                break;

            case 3:
                System.Environment.Exit(0);
                break;
        }
    }

List<Carros> BuscaCarros(int campo, string busca)
{
    List<Carros> carros = new List<Carros>();

    switch(campo)
    {
        case 1:
            carros = repositorio.GetByMarca(busca);
            break;

        case 2:
            carros = repositorio.GetByModelo(busca);
            break;

        case 3:
            carros = repositorio.GetByCor(busca);
            break;

        case 4:
            carros = repositorio.GetByCilindradas(double.Parse(busca));
            break;

        case 5:
            carros = repositorio.GetByPotencia(int.Parse(busca));
            break;

        case 6:
            carros = repositorio.GetByAno(int.Parse(busca));
            break;

        case 7:
            carros = repositorio.GetByDataVenda(DateTime.Parse(busca));
            break;
    }

    return carros;
}

void DeletarCarro(Guid id)
{
    Carros carro = repositorio.GetById(id);
    repositorio.ExcluirCarro(carro);

    Console.WriteLine();
    Console.WriteLine("Item excluído. Pressione qualquer tecla para prosseguir.");
    Console.ReadKey(true);
    Console.Clear();
}

void EditarCarro(Guid id)
{
    Carros carro = repositorio.GetById(id);
    string entrada;

    Console.Clear();
    Console.WriteLine("MODIFICAR REGISTRO");
    Console.WriteLine("------------------");
    Console.WriteLine("- deixe o registro em branco para manter o valor atual -");
    Console.WriteLine();
    Menus.ExibeCarro(carro);

    Console.Write("Marca: ");
    entrada = Console.ReadLine();
    if (entrada != "") carro.Marca = entrada;

    Console.Write("Modelo: ");
    entrada = Console.ReadLine();
    if (entrada != "") carro.Modelo = entrada;

    Console.Write("Cor: ");
    entrada = Console.ReadLine();
    if (entrada != "") carro.Cor = entrada;

    Console.Write("Cilindradas: ");
    entrada = Console.ReadLine();
    if (entrada != "" && double.TryParse(entrada, out double nada1)) carro.Cilindradas = double.Parse(entrada);

    Console.Write("Potencia: ");
    entrada = Console.ReadLine();
    if (entrada != "" && int.TryParse(entrada, out int nada2)) carro.Potencia = int.Parse(entrada);

    Console.Write("Ano de fabricação: ");
    entrada = Console.ReadLine();
    if (entrada != "" && int.TryParse(entrada, out int nada3)) carro.Ano = int.Parse(entrada);

    Console.Write("Data da venda: ");
    entrada = Console.ReadLine();
    if (entrada != "" && DateTime.TryParse(entrada, out DateTime nada4)) carro.DataVenda = DateTime.Parse(entrada);

    Console.Clear();
    Console.WriteLine("VEÍCULO MODIFICADO:");
    Console.WriteLine("-------------------");
    Console.WriteLine();
    Menus.ExibeCarro(carro);

    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para prosseguir.");
    Console.ReadKey(true);
    Console.Clear();
}
