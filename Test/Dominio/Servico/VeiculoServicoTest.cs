using Minimalapi.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using Test.Infraestrutura;

namespace Test.Dominio.Servico;

public class VeiculoServicoTest
{

    [TestMethod]
    public void TestandoSalvarVeiculo()
    {
        var contextoConexao = new CriarContextoTest();

        var contexto = contextoConexao.Criar();
        contexto.Veiculos.RemoveRange(contexto.Veiculos.ToList());
        contexto.SaveChanges();

        var veiculo = new Veiculo
        {
            Nome = "Hylux",
            Marca = "Toyta",
            Ano = 2025
        };

        var veiculoServico = new VeiculoServico(contexto);
        veiculoServico.Incluir(veiculo);

        var todos = veiculoServico.Todos(1);
        Assert.AreEqual(1, todos.Count);

    }

    [TestMethod]
    public void TestandoBuscarVeiculos()
    {
        var contextoConexao = new CriarContextoTest();
        var contexto = contextoConexao.Criar();

        contexto.Veiculos.RemoveRange(contexto.Veiculos.ToList());
        contexto.SaveChanges();

        var veiculoServico = new VeiculoServico(contexto);

        var veiculos = new List<Veiculo>
        {
            new Veiculo { Nome = "Hilux", Marca = "Toyota", Ano = 2022 },
            new Veiculo { Nome = "Civic", Marca = "Honda", Ano = 2021 },
            new Veiculo { Nome = "Onix", Marca = "Chevrolet", Ano = 2023 }
        };

        foreach (var veiculo in veiculos)
        {
            veiculoServico.Incluir(veiculo);
        }

        var resultado = veiculoServico.Todos();

        Assert.IsNotNull(resultado);
        Assert.AreEqual(3, resultado.Count);
        Assert.IsTrue(resultado.Any(v => v.Nome == "Hilux"));
        Assert.IsTrue(resultado.Any(v => v.Nome == "Civic"));
        Assert.IsTrue(resultado.Any(v => v.Nome == "Onix"));
    }

    [TestMethod]
    public void TestandoBuscarPorId()
    {
        var contextoConexao = new CriarContextoTest();

        var contexto = contextoConexao.Criar();
        contexto.Veiculos.RemoveRange(contexto.Veiculos.ToList());
        contexto.SaveChanges();

        var veiculo = new Veiculo
        {
            Nome = "Hylux",
            Marca = "Toyta",
            Ano = 2025
        };

        var veiculoServico = new VeiculoServico(contexto);
        veiculoServico.Incluir(veiculo);

        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        Assert.IsNotNull(veiculoDoBanco);
        Assert.AreEqual(veiculo.Id, veiculoDoBanco.Id);
    }

    [TestMethod]
    public void TestandoAlterarVeiculo()
    {
        var contextoConexao = new CriarContextoTest();

        var contexto = contextoConexao.Criar();
        contexto.Veiculos.RemoveRange(contexto.Veiculos.ToList());
        contexto.SaveChanges();

        var veiculo = new Veiculo
        {
            Nome = "Hylux",
            Marca = "Toyta",
            Ano = 2026
        };

        var veiculoServico = new VeiculoServico(contexto);
        veiculoServico.Atualizar(veiculo);

        var veiculoAlterado = veiculoServico.BuscaPorId(veiculo.Id);

        Assert.IsNotNull(veiculoAlterado);
        Assert.AreEqual("Hilux SRV", veiculoAlterado.Nome);
        Assert.AreEqual("Toyota", veiculoAlterado.Marca);
        Assert.AreEqual(2026, veiculoAlterado.Ano);
    }

    [TestMethod]
    public void TestandoApagarVeiculo()
    {
        var contextoConexao = new CriarContextoTest();
        var contexto = contextoConexao.Criar();

        contexto.Veiculos.RemoveRange(contexto.Veiculos.ToList());
        contexto.SaveChanges();

        var veiculo = new Veiculo
        {
            Nome = "Hilux",
            Marca = "Toyota",
            Ano = 2026
        };

        var veiculoServico = new VeiculoServico(contexto);
        veiculoServico.Incluir(veiculo);

        veiculoServico.Apagar(veiculo);

        var veiculoExcluido = veiculoServico.BuscaPorId(veiculo.Id);

        Assert.IsNull(veiculoExcluido);
    }


}