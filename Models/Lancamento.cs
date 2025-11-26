namespace FinanceiroApp.Models;

using System.ComponentModel.DataAnnotations;

public class Lancamento
{
    public int Id { get; set; }
    public string Tipo { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Pessoa { get; set; } = "";
    public DateTime DataLancamento { get; set; } = DateTime.Today;
    public DateTime DataVencimento { get; set; } = DateTime.Today;
    public DateTime? DataPagamento { get; set; }
    public int? FornecedorId { get; set; }
    public Fornecedor? Fornecedor { get; set; }
    
    [Required(ErrorMessage = "O campo Valor é obrigatório")]
    public decimal Valor { get; set; }
    public string Status { get; set; } = "Aberto";

    public int? CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
