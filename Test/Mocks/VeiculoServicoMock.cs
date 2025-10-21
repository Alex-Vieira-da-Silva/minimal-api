using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> _veiculos = new List<Veiculo>
    {
        new Veiculo
        {
            Id = 1,
            Nome = "Hilux",
            Marca = "Toyota",
            Ano = 2022
        },
        new Veiculo
        {
            Id = 2,
            Nome = "Civic",
            Marca = "Honda",
            Ano = 2021
        }
    };

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        var resultado = _veiculos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
            resultado = resultado.Where(v => v.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(marca))
            resultado = resultado.Where(v => v.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase));

        return resultado.ToList();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _veiculos.FirstOrDefault(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = _veiculos.Count > 0 ? _veiculos.Max(v => v.Id) + 1 : 1;
        _veiculos.Add(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        var index = _veiculos.FindIndex(v => v.Id == veiculo.Id);
        if (index >= 0)
            _veiculos[index] = veiculo;
    }

    public void Apagar(Veiculo veiculo)
    {
        _veiculos.RemoveAll(v => v.Id == veiculo.Id);
    }
}