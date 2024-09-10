using ImportacaoDeArquivos.Repositories;
using ImportacaoDeArquivos.Services;
using Microsoft.Extensions.Configuration;


class Program
{
    public static IConfiguration Configuration { get; private set; }

    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();

        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        var clienteReader = new ClienteFileReader();
        var contaReader = new ContaFileReader();
        var plasticoReader = new PlasticoFileReader();
        var transacaoReader = new TransacaoFileReader();

        var clienteRepository = new ClienteRepository(connectionString);
        var contaRepository = new ContaRepository(connectionString);
        var plasticoRepository = new PlasticoRepository(connectionString);
        var transacaoRepository = new TransacaoRepository(connectionString);

        var processor = new FileProcessor(
            clienteReader,
            contaReader,
            plasticoReader,
            transacaoReader,
            clienteRepository,
            contaRepository,
            plasticoRepository,
            transacaoRepository
        );

        processor.Process("./Files");

        Console.WriteLine("Importação concluída com sucesso!");
    }
}
