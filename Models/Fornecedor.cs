namespace FinanceiroApp.Models;

public class Fornecedor
{
    public int Id { get; set; }
    public string RazaoSocial { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
}
