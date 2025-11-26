---
description: Como compilar a aplicação para Linux
---

# Compilar para Linux

Para gerar os arquivos executáveis para um servidor Linux (ex: Ubuntu, Debian), execute o seguinte comando no terminal:

```powershell
dotnet publish -c Release -r linux-x64 --self-contained
```

### Explicação dos parâmetros:
- `-c Release`: Compila em modo de produção (otimizado).
- `-r linux-x64`: Define o "Runtime Identifier" para Linux 64-bit.
- `--self-contained`: Inclui o .NET Runtime junto com a aplicação. Isso significa que o servidor Linux **não precisa** ter o .NET instalado, mas o arquivo final ficará maior.

### Se o servidor JÁ TIVER o .NET instalado:
Você pode gerar um arquivo menor usando:
```powershell
dotnet publish -c Release -r linux-x64 --no-self-contained
```

### Onde ficam os arquivos?
Os arquivos gerados estarão em:
`bin\Release\net8.0\linux-x64\publish\`

Você deve copiar todo o conteúdo desta pasta para o seu servidor Linux.

### Como rodar no Linux?
1. Dê permissão de execução: `chmod +x FinanceiroApp`
2. Execute: `./FinanceiroApp`
