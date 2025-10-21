using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Minimalapi.Infraestrutura.Db;

namespace Test.Infraestrutura;

public class CriarContextoTest
{
    public DbContexto Criar()
    {
        var build = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

        var configuracao = build.Build();
        var connectionString = configuracao.GetConnectionString("Mysql");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("A string de conexão 'Mysql' está ausente ou vazia.");

        var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new DbContexto(optionsBuilder.Options, configuracao);
    }
}