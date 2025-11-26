using FinanceiroApp.Models;

namespace FinanceiroApp.Services;

public class CategoriaService
{
    private readonly List<Categoria> _categorias = new();

    public CategoriaService()
    {
        _categorias.Add(new Categoria { Id = 1, Nome = "Aluguel", Tipo = "Pagar" });
        _categorias.Add(new Categoria { Id = 2, Nome = "Salario", Tipo = "Receber" });
        _categorias.Add(new Categoria { Id = 3, Nome = "Servicos", Tipo = "Ambos" });
    }

    public Task<List<Categoria>> ObterTodasAsync()
    {
        return Task.FromResult(_categorias.ToList());
    }

    public Task<Categoria?> ObterPorIdAsync(int id)
    {
        return Task.FromResult(_categorias.FirstOrDefault(c => c.Id == id));
    }
    public Task SalvarAsync(Categoria categoria)
    {
        if (categoria.Id == 0)
        {
            // Simples auto-incremento para mock
            categoria.Id = _categorias.Any() ? _categorias.Max(c => c.Id) + 1 : 1;
            _categorias.Add(categoria);
        }
        else
        {
            var existente = _categorias.FirstOrDefault(c => c.Id == categoria.Id);
            if (existente != null)
            {
                existente.Nome = categoria.Nome;
                existente.Tipo = categoria.Tipo;
            }
        }
        return Task.CompletedTask;
    }

    public Task ExcluirAsync(int id)
    {
        var categoria = _categorias.FirstOrDefault(c => c.Id == id);
        if (categoria != null)
        {
            _categorias.Remove(categoria);
        }
        return Task.CompletedTask;
    }
}
