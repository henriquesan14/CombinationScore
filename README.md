# API GraphQL - Gerar combinação possivel de número alvo

### Features

- [x] API GraphQL para uma combinação possivel com um número alvo


### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:
- [.NET](https://dotnet.microsoft.com/en-us/) 
- [GraphQL](https://graphql.org/)
- [HotChocolate](https://chillicream.com/docs/hotchocolate)
- [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)

### 🛠 Padrões Utilizados

As seguintes padrões foram usados na construção do projeto:
- DDD (Domain-Driven Design)
- SOLID

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET](https://dotnet.microsoft.com/en-us/).
[SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-2019) ou imagem utilizando o [Docker](https://www.docker.com/).
Além disto é bom ter um editor para trabalhar com o código como [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) ou [VSCode](https://code.visualstudio.com/).
Também é preciso configurar a string de conexão com banco de dados no arquivo `CombinationScore/src/ScoreCombination.API/appsettings.json` , altere o valor da propriedade "DbConnection".

### 🎲 Rodando o Back End (servidor)

#### Rodando ScoreCombination.API

```bash
# Clone este repositório
$ git clone <https://github.com/henriquesan14/CombinationScore.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd CombinationScore

# Vá para a pasta da ScoreCombination.API
$ cd src/ScoreCombination.API

# Execute a aplicação com o comando do dotnet
$ dotnet run

# A API iniciará na porta:5000 com HTTP e na porta:5001 com HTTPS - acesse <http://localhost:5001>
```

### : 🌎 Realizando chamadas no GraphQL

#### Exemplo para buscar uma combinação possivel

```json
    query{
        combination(combination: {sequence: [5, 20, 2, 1], target: 47}) {
            hasCombination,
            combination
        }
    }
```

#### Exemplo para buscar histórico de pesquisas com filtro de datas

```json
    query{
        requestsCombinations (filter: {dateInitial:"2022-06-01", dateFinal: "2022-06-25"}) {
            request,
            response,
            createdAt
        }
    }
```



### Autor
---

<a href="https://www.linkedin.com/in/henrique-san/">
 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/33522361?v=4" width="100px;" alt=""/>
 <br />
 <sub><b>Henrique Santos</b></sub></a> <a href="https://www.linkedin.com/in/henrique-san/">🚀</a>


Feito com ❤️ por Henrique Santos 👋🏽 Entre em contato!

[![Linkedin Badge](https://img.shields.io/badge/-Henrique-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/henrique-san/)](https://www.linkedin.com/in/henrique-san/) 
