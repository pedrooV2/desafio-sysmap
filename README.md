# Sysmap _Challenge_
### Objetivo 
Criar uma automação para pesquisar temas na plataforma Alura. A automação tem como requisito a implementação de DDD, Injeção de Dependência, Selenium e boas práticas de código.

## Guia do Dev.
### Requerimentos
- .NET 8 Runtime. [Clique aqui para baixar](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- Ao utilizar o Visual Studio 2022 para DEBUG, certifique-se de estar utilizando a última versão disponível.

### Como Executar?
```bash
# Clone esse repositório
git clone https://github.com/pedrooV2/desafio-sysmap.git

# Vá até o diretório AluraBot.Data
cd .\AluraBot.Data\

# Execute o seguinte comando para criar o banco SQLite
dotnet ef --startup-project ..\AluraBot.Application\AluraBot.Application.csproj --project .\AluraBot.Data.csproj database update

# Obs.: Caso as migrações não estejam criadas no projeto, execute o seguinte comando, e depois repita o comando #1
dotnet ef --startup-project ..\AluraBot.Application\AluraBot.Application.csproj --project .\AluraBot.Data.csproj migrations add InitialCreation

# Execute o projeto
dotnet build
dotnet run
```
### Ferramentas Utilizadas
- Selenium 
- Entity Framework
- SQLite
- Html Agility Pack

### Desenvolvido por
<table>
  <tr>
    <td align="center">
      <a href="https://github.com/pedrooV2"><img style="border-radius: 50%;" src="https://github.com/pedrooV2.png" width="100px" alt="Foto de perfil do Github"/>
        <br />
        <sub><b>Pedro Lucas Bezerra</b></sub></a>
      <br />
    </td>
  </tr>
</table>

