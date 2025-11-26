using FinanceiroApp.Models;

namespace FinanceiroApp.Services;

public class LancamentoService
{
    private readonly List<Lancamento> _lancamentos = new();
    private int _ultimoId = 0;
    private readonly CategoriaService _categoriaService;
    private readonly FornecedorService _fornecedorService;

    public LancamentoService(CategoriaService categoriaService, FornecedorService fornecedorService)
    {
        _categoriaService = categoriaService;
        _fornecedorService = fornecedorService;

        // dados de exemplo
        _lancamentos.Add(new Lancamento
        {
            Id = ++_ultimoId,
            Tipo = "Pagar",
            Descricao = "Aluguel escritorio",
            Pessoa = "Imobiliaria ABC",
            DataLancamento = DateTime.Today.AddDays(-5),
            DataVencimento = DateTime.Today.AddDays(5),
            Valor = 2500m,
            Status = "Aberto",
            CategoriaId = 1
        });

        _lancamentos.Add(new Lancamento
        {
            Id = ++_ultimoId,
            Tipo = "Receber",
            Descricao = "Pagamento cliente X",
            Pessoa = "Cliente X",
            DataLancamento = DateTime.Today.AddDays(-2),
            DataVencimento = DateTime.Today.AddDays(2),
            Valor = 1500m,
            Status = "Aberto",
            CategoriaId = 2
        });
    }

    private async Task HidratarLancamentos(IEnumerable<Lancamento> lancamentos)
    {
        var categorias = await _categoriaService.ObterTodasAsync();
        var fornecedores = await _fornecedorService.ObterTodosAsync();

        foreach (var l in lancamentos)
        {
            if (l.CategoriaId.HasValue)
                l.Categoria = categorias.FirstOrDefault(c => c.Id == l.CategoriaId);
            
            if (l.FornecedorId.HasValue)
                l.Fornecedor = fornecedores.FirstOrDefault(f => f.Id == l.FornecedorId);
        }
    }

    public async Task<List<Lancamento>> ObterTodosAsync()
    {
        await HidratarLancamentos(_lancamentos);
        return _lancamentos.ToList();
    }

    public async Task<List<Lancamento>> ObterPorTipoAsync(string tipo)
    {
        var lista = _lancamentos.Where(l => l.Tipo == tipo).ToList();
        await HidratarLancamentos(lista);
        return lista;
    }

    public async Task<Lancamento?> ObterPorIdAsync(int id)
    {
        var lanc = _lancamentos.FirstOrDefault(l => l.Id == id);
        if (lanc != null)
        {
            await HidratarLancamentos(new[] { lanc });
        }
        return lanc;
    }

    public Task SalvarAsync(Lancamento lancamento)
    {
        // Garantir consistência da Data de Pagamento
        if (lancamento.Status == "Pago" && lancamento.DataPagamento == null)
        {
            lancamento.DataPagamento = DateTime.Today;
        }
        else if (lancamento.Status != "Pago")
        {
            lancamento.DataPagamento = null;
        }

        if (lancamento.Id == 0)
        {
            lancamento.Id = ++_ultimoId;
            _lancamentos.Add(lancamento);
        }
        else
        {
            var existente = _lancamentos.FirstOrDefault(l => l.Id == lancamento.Id);
            if (existente != null)
            {
                existente.Tipo = lancamento.Tipo;
                existente.Descricao = lancamento.Descricao;
                existente.Pessoa = lancamento.Pessoa;
                existente.DataLancamento = lancamento.DataLancamento;
                existente.DataVencimento = lancamento.DataVencimento;
                existente.DataPagamento = lancamento.DataPagamento;
                existente.Valor = lancamento.Valor;
                existente.Status = lancamento.Status;
                existente.CategoriaId = lancamento.CategoriaId;
                existente.FornecedorId = lancamento.FornecedorId;
            }
        }

        return Task.CompletedTask;
    }

    public Task MarcarComoPagoAsync(int id)
    {
        var lanc = _lancamentos.FirstOrDefault(l => l.Id == id);
        if (lanc != null)
        {
            lanc.Status = "Pago";
            lanc.DataPagamento = DateTime.Today;
        }

        return Task.CompletedTask;
    }

    public Task ExcluirAsync(int id)
    {
        var lanc = _lancamentos.FirstOrDefault(l => l.Id == id);
        if (lanc != null)
        {
            _lancamentos.Remove(lanc);
        }
        return Task.CompletedTask;
    }
}
