# TravelRouteAPI

### Visão Geral

O projeto utiliza/contém: 
- **.NET 9 Minimal API** como design de API.
- **Swagger** como UI e documentação da API.
- **EFCore 9.0.7** como ORM.
- **PostgreSQL** como banco de dados.
- **Clean Architecture** como design pattern.
- **Domain Driven Design** como design pattern.
- **CQS/CQRS** como design pattern.


### Executando as Migrações

* (Necessário inserir/alterar `appsettings.Dev.json` passando a string de conexão do seu usuário no postgreSQL) *
```bash
"ConnectionStrings": {
    "AppDbContext": "Host=localhost;Port=5432;Database=TravelRouteDb;Username=[username];Password=[password];IncludeErrorDetail=True"
}
```  

Para criar o banco de dados e executar as migrações, a partir da raiz do projeto (onde está o arquivo .sln), navegue até a pasta `Infrastructure` e execute:


```bash
$env:ASPNETCORE_ENVIRONMENT = "Dev"
```
* Este primeiro comando vai apontar a variavel de ambiente pro ambiente correto. *

```bash
dotnet ef database update
```
* Este segundo comando vai aplicar o migration ja existente ao seu banco de dados. *

Vai criar e atualizar o schema do seu banco corretamente, já incluindo DataSeeding inicial.

### Informações Adicionais

- A camada de `API` contém os endpoints da MinimalAPI, Swagger, etc...
- A camada de `Application` contém a lógica da aplicação (Command/Query/Request/Response/DI).
- A camada de `Domain` contém o modelo de negócio e o algoritmo principal que gera as rotas pela regra estabelecida.
- A camada de `Infrastructure` contém toda a lógica relacionada a dados, incluindo o `DbContext`, migrações e `seeding` de dados.
- Para executar o swagger, com a aplicação executando basta inserir a URL: https://localhost:5000/swagger/index.html