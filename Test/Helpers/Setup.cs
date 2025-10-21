using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Minimalapi.Infraestrutura.Db;
using MinimalApi.Dominio.Interfaces;
using Test.Mocks;

namespace Test.Helpers;

public class Setup
{
    public const string Port = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext context)
    {
        Setup.testContext = context;
        Setup.http = new WebApplicationFactory<Startup>();
        http = new WebApplicationFactory<Startup>();

        Setup.http = http.WithWebHostBuilder(builder =>
        {
            builder.UseSetting("https_port", Setup.Port).UseEnvironment("Testing");
            builder.ConfigureServices(services =>
             {
                 services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                 services.AddScoped<IVeiculoServico, VeiculoServicoMock>();
             });
        });

        Setup.client = Setup.http.CreateClient();

    }
    
    public static void ClassCleanup()
    {
        Setup.http.Dispose();
    }

}