using Minimalapi.Infraestrutura.Db;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores
            .Where(a => a.Id == id)
            .FirstOrDefault(); 
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();
        return administrador;
    }

    public Administrador? Login(LogindDTO loginDTO)
    {
        return _contexto.Administradores
            .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha)
            .FirstOrDefault();
    }

    public List<Administrador> Todos(int? pagina)
    {
        var administradores = _contexto.Administradores.AsQueryable();

        int tamanhoPagina = 10;

        if (pagina != null && pagina > 0)
        {
            administradores = administradores
                .Skip(((int)pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina);
        }

        return administradores.ToList();
    }
}