---
description: Como instalar e executar a aplicação no Windows
---

# Instalar e Executar no Windows

Para gerar um executável (.exe) que pode rodar em qualquer computador Windows (mesmo sem .NET instalado), siga os passos:

## 1. Gerar o Executável (Publish)

Abra o terminal na pasta do projeto e execute:

```powershell
dotnet publish -c Release -r win-x64 --self-contained
```

### Explicação:
- `-c Release`: Otimiza para produção.
- `-r win-x64`: Gera para Windows 64-bit.
- `--self-contained`: Inclui tudo que é necessário. O usuário final **não precisa** instalar o .NET.

## 2. Localizar os Arquivos

Os arquivos gerados estarão em:
`bin\Release\net8.0\win-x64\publish\`

## 3. Executar

1. Copie o conteúdo da pasta `publish` para o local desejado (ex: `C:\FinanceiroApp`).
2. Dê um duplo clique no arquivo **FinanceiroApp.exe**.
3. O navegador deve abrir automaticamente ou você pode acessar `http://localhost:5000` (ou a porta configurada).

> **Dica**: Você pode criar um atalho para o `.exe` na Área de Trabalho para facilitar o acesso.
