# FinanceiroApp

Um sistema moderno de gestão financeira desenvolvido com **Blazor Web App** e **Tailwind CSS**.

## 🚀 Sobre o Projeto

O **FinanceiroApp** é uma aplicação web para controle de contas a pagar e receber, projetada para ser rápida, responsiva e fácil de usar. Ele permite gerenciar lançamentos financeiros, fornecedores e categorias de forma intuitiva.

## ✨ Funcionalidades Principais

*   **Dashboard**: Visão geral rápida da situação financeira.
*   **Contas a Pagar e Receber**:
    *   Listagem com filtros de data e busca textual.
    *   Totalizadores automáticos no rodapé.
    *   Status visual (Aberto, Pago, Atrasado).
*   **Lançamentos**:
    *   Cadastro completo com suporte a Fornecedores e Categorias.
    *   **Data de Pagamento Inteligente**: Preenchimento automático ao marcar como "Pago" e limpeza ao reabrir.
    *   Validação de dados e campos somente leitura quando apropriado.
*   **Gestão de Cadastros (CRUD)**:
    *   **Fornecedores**: Cadastro com Razão Social e CNPJ.
    *   **Categorias**: Organização por Tipo (Pagar, Receber, Ambos).
    *   **Busca Integrada**: Filtre fornecedores e categorias em tempo real.
*   **Interface Moderna**:
    *   Layout responsivo (Mobile-first) ocupando 100% da tela.
    *   Modais de busca avançada para seleção de registros.
    *   Estilização premium com Tailwind CSS.

## 🛠️ Tecnologias Utilizadas

*   **[.NET 8](https://dotnet.microsoft.com/)**: Plataforma de desenvolvimento robusta e de alta performance.
*   **[Blazor Web App](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)**: Framework para construção de UI interativa com C#.
*   **[Tailwind CSS](https://tailwindcss.com/)**: Framework CSS utilitário para design rápido e customizável.
*   **Entity Framework Core** (Simulado em memória para este protótipo): Camada de dados.

## 📦 Como Executar Localmente

1.  **Pré-requisitos**: Tenha o [.NET SDK 8.0](https://dotnet.microsoft.com/download) instalado.
2.  Clone o repositório ou baixe os arquivos.
3.  Abra o terminal na pasta do projeto.
4.  Execute o comando:

    ```powershell
    dotnet watch
    ```

    O comando `dotnet watch` iniciará a aplicação e recarregará automaticamente se houver alterações no código (Hot Reload).

## 🔨 Como Compilar (Build)

### Para Windows
Gera um executável único que não depende do .NET instalado:
```powershell
dotnet publish -c Release -r win-x64 --self-contained
```
*Consulte `.agent/workflows/install_run_windows.md` para mais detalhes.*

### Para Linux
Gera os binários para servidores Linux:
```powershell
dotnet publish -c Release -r linux-x64 --self-contained
```
*Consulte `.agent/workflows/compile_linux.md` para mais detalhes.*

## 📝 Estrutura do Projeto

*   `Components/Pages`: Páginas da aplicação (Razor Components).
*   `Components/Layout`: Layouts compartilhados (Menu, Cabeçalho).
*   `Components/Shared`: Componentes reutilizáveis (ex: SearchModal).
*   `Services`: Lógica de negócios e acesso a dados.
*   `Models`: Definição das entidades (Lancamento, Fornecedor, Categoria).
*   `wwwroot`: Arquivos estáticos (CSS, Imagens).

---
Desenvolvido com ❤️ usando .NET e Blazor.
