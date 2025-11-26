using FinanceiroApp.Models;

namespace FinanceiroApp.Services;

public class FornecedorService
{
    private readonly List<Fornecedor> _fornecedores = new();
    private int _ultimoId = 0;

    public FornecedorService()
    {
        // Mock data
        _fornecedores.Add(new Fornecedor { Id = ++_ultimoId, RazaoSocial = "Fornecedor A", CNPJ = "12.345.678/0001-90" });
        _fornecedores.Add(new Fornecedor { Id = ++_ultimoId, RazaoSocial = "Fornecedor B", CNPJ = "98.765.432/0001-10" });
        _fornecedores.Add(new Fornecedor { Id = ++_ultimoId, RazaoSocial = "Cliente X", CNPJ = "11.111.111/0001-11" });
    }

    public Task<List<Fornecedor>> ObterTodosAsync()
    {
        return Task.FromResult(_fornecedores.ToList());
    }

    public Task<Fornecedor?> ObterPorIdAsync(int id)
    {
        var fornecedor = _fornecedores.FirstOrDefault(f => f.Id == id);
        return Task.FromResult(fornecedor);
    }
    public Task SalvarAsync(Fornecedor fornecedor)
    {
        if (fornecedor.Id == 0)
        {
            fornecedor.Id = ++_ultimoId;
            _fornecedores.Add(fornecedor);
        }
        else
        {
            var existente = _fornecedores.FirstOrDefault(f => f.Id == fornecedor.Id);
            if (existente != null)
            {
                existente.RazaoSocial = fornecedor.RazaoSocial;
                existente.CNPJ = fornecedor.CNPJ;
            }
        }
        return Task.CompletedTask;
    }

    public Task ExcluirAsync(int id)
    {
        var fornecedor = _fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor != null)
        {
            _fornecedores.Remove(fornecedor);
        }
        return Task.CompletedTask;
    }
}
