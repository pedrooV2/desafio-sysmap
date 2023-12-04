# Sysmap _Challenge_
### :dart: Objetivo 
Criar uma automação para pesquisar temas na plataforma Alura. A automação tem como requisito a implementação de DDD, Injeção de Dependência, Selenium e boas práticas de código.

## Guia do Dev.
### :milky_way: Requerimentos
- .NET 8 Runtime. [Clique aqui para baixar](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- Ao utilizar o Visual Studio 2022 para DEBUG, certifique-se de estar utilizando a última versão disponível.

### :sparkles: Como Executar?
Execute os seguintes comandos para executar o projeto
```bash
# Clone esse repositório
git clone https://github.com/pedrooV2/desafio-sysmap.git

# Vá até o diretório AluraBot.Data
cd .\AluraBot.Data\

# Execute o seguinte comando para criar o banco SQLite
dotnet ef --startup-project ..\AluraBot.Application\AluraBot.Application.csproj --project .\AluraBot.Data.csproj database update

# Retornar para o diretório da solução, e acessar o diretório do projeto Worker Service
cd ..
cd .\AluraBot.Application\

# Execute o projeto
dotnet build
dotnet run
```

Obs. Caso o comando para criar o banco falhe, pode ser necessário executar algumas ações
```bash
# Caso não tiver a CLI do Entity Framework instalada na máquina, execute o comando abaixo
dotnet tool install --global dotnet-ef

# Caso as migrações não estejam criadas no projeto, execute o seguinte comando, e depois repita o comando para criar o banco SQLite
dotnet ef --startup-project ..\AluraBot.Application\AluraBot.Application.csproj --project .\AluraBot.Data.csproj migrations add InitialCreation
```

### :blue_book: Ferramentas Utilizadas
- Selenium 
- Entity Framework
- SQLite
- Html Agility Pack

### :v: Desenvolvido por
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

