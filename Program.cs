using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("=========================================");
Console.WriteLine("  Bem-vindo ao sistema de reservas do Hotel!");
Console.WriteLine("=========================================\n");

// Escolha da suíte
Console.WriteLine("Escolha o tipo de suíte:");
Console.WriteLine("1 - Simples\n2 - Luxo\n3 - Premium");
Console.Write("Digite a opção: ");
int escolha = Convert.ToInt32(Console.ReadLine());

string tipoSuite = escolha switch
{
    1 => "Simples",
    2 => "Luxo",
    3 => "Premium",
    _ => "Simples"
};

// Valor da diária e capacidade por tipo
decimal valorDiaria = escolha switch
{
    1 => 100,
    2 => 200,
    3 => 300,
    _ => 100
};

int capacidadeSuite = escolha switch
{
    1 => 2,
    2 => 3,
    3 => 4,
    _ => 2
};

Suite suite = new Suite(tipoSuite, capacidadeSuite, valorDiaria);

// Dias reservados
Console.Write("Quantos dias deseja reservar? ");
int dias = Convert.ToInt32(Console.ReadLine());

// Data de entrada
Console.Write("Informe a data de entrada (dd/MM/yyyy): ");
DateTime dataEntrada = DateTime.Parse(Console.ReadLine());
DateTime dataSaida = dataEntrada.AddDays(dias);

// Número de hóspedes
Console.Write("Quantos hóspedes estarão na reserva? ");
int qtdHospedes = Convert.ToInt32(Console.ReadLine());

// Cadastro dos hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
for (int i = 1; i <= qtdHospedes; i++)
{
    Console.Write($"Digite o nome do hóspede {i}: ");
    string nome = Console.ReadLine();

    Console.Write($"Digite o sobrenome do hóspede {i}: ");
    string sobrenome = Console.ReadLine();

    hospedes.Add(new Pessoa(nome, sobrenome));
}

// Criar a reserva
Reserva reserva = new Reserva(dias);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibir resumo da reserva
Console.WriteLine("\n=========================================");
Console.WriteLine("            RESUMO DA RESERVA            ");
Console.WriteLine("=========================================");
Console.WriteLine($"Suíte escolhida: {suite.TipoSuite}");
Console.WriteLine($"Capacidade da suíte: {suite.Capacidade} pessoa(s)");
Console.WriteLine($"Valor da diária: R$ {suite.ValorDiaria:F2}");
Console.WriteLine($"Data de entrada: {dataEntrada:dd/MM/yyyy}");
Console.WriteLine($"Data de saída:   {dataSaida:dd/MM/yyyy}");
Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");

Console.WriteLine("\nHóspedes:");
foreach (Pessoa p in hospedes)
{
    Console.WriteLine($"- {p.NomeCompleto}");
}

Console.WriteLine($"\nValor total da reserva: R$ {reserva.CalcularValorDiaria():F2}");
Console.WriteLine("=========================================\n");

Console.WriteLine("Obrigado por usar nosso sistema de reservas!");
