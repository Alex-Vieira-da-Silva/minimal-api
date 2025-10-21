using Minimalapi.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using Test.Infraestrutura;

namespace Test.Dominio.Servico;

public class AdministradorServicoTest
{

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        var contextoConexao = new CriarContextoTest();

        var contexto = contextoConexao.Criar();
        contexto.Administradores.RemoveRange(contexto.Administradores.ToList());
        contexto.SaveChanges();

        var adm = new Administrador
        {
            Nome = "Administrador Teste",
            Email = "admin@teste.com",
            Senha = "senha123",
            Perfil = "Adm"
        };

        var administradorServico = new AdministradorServico(contexto);
        administradorServico.Incluir(adm);

        var todos = administradorServico.Todos(1);
        Assert.AreEqual(1, todos.Count);

    }

    [TestMethod]
    public void TestandoBuscarAdministradores()
    {
        var contextoConexao = new CriarContextoTest();
        var contexto = contextoConexao.Criar();


        contexto.Administradores.RemoveRange(contexto.Administradores.ToList());
        contexto.SaveChanges();

        var administradorServico = new AdministradorServico(contexto);


        var administradores = new List<Administrador>
        {
            new Administrador { Nome = "Admin 1", Email = "admin1@teste.com", Senha = "senha1", Perfil = "Adm" },
            new Administrador { Nome = "Admin 2", Email = "admin2@teste.com", Senha = "senha2", Perfil = "Adm" },
            new Administrador { Nome = "Admin 3", Email = "admin3@teste.com", Senha = "senha3", Perfil = "Adm" }
        };

        foreach (var adm in administradores)
        {
            administradorServico.Incluir(adm);
        }

        var resultado = administradorServico.Todos(1);

        Assert.IsNotNull(resultado);
        Assert.AreEqual(3, resultado.Count);
        Assert.IsTrue(resultado.Any(a => a.Email == "admin1@teste.com"));
        Assert.IsTrue(resultado.Any(a => a.Email == "admin2@teste.com"));
        Assert.IsTrue(resultado.Any(a => a.Email == "admin3@teste.com"));
    }

    [TestMethod]
    public void TestandoBuscarPorId()
    {
        var contextoConexao = new CriarContextoTest();

        var contexto = contextoConexao.Criar();
        contexto.Administradores.RemoveRange(contexto.Administradores.ToList());
        contexto.SaveChanges();

        var adm = new Administrador
        {
            Nome = "Administrador Teste",
            Email = "admin@teste.com",
            Senha = "senha123",
            Perfil = "Adm"
        };

        var administradorServico = new AdministradorServico(contexto);
        administradorServico.Incluir(adm);

        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        Assert.IsNotNull(admDoBanco);
        Assert.AreEqual(adm.Id, admDoBanco.Id);
    }

}