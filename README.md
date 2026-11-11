# RAP

API web em camadas (.NET 6) para contas, organizações e batalhas. A solução é `RAP.sln`. Quase todas as rotas exigem JWT; o Swagger abre só no ambiente de desenvolvimento.

## Funcionalidades

O login e o cadastro são anônimos. As demais rotas pedem `Authorization: Bearer <token>`.

- `POST /api/Auth/Login` e `POST /api/Auth/Register` — autenticação e cadastro (Identity)
- `POST /api/Auth/DeslogarUsuario` — apaga o registro em `LoginCache`
- `GET /api/Usuario` — busca por nome ou apelido
- `GET` e `POST /api/Organizacao` — filtro, organizações do usuário e criação
- `GET /api/Batalha`, `POST /api/Batalha/CriarBatalha`, `POST /api/Batalha/EditarBatalha` e `DELETE /api/Batalha/ExcluirBatalha` — consulta, criação e edição de batalhas

## Tecnologias

.NET 6, ASP.NET Core, EF Core 6 (SQL Server), ASP.NET Identity, JWT Bearer, MediatR, Autofac, AutoMapper, Dapper e Swagger (Swashbuckle).

## Arquitetura

`RAP` é o projeto web (controladores, JWT, Swagger e Autofac). `Application` guarda DTOs, comandos e interfaces. `Domain` implementa os serviços e referencia `Application` e `Infraestructure`. `Infraestructure` tem o contexto do EF, as migrações, os repositórios (EF e Dapper) e o perfil do AutoMapper. O Autofac registra as implementações dessas camadas.

## Como rodar

É preciso o SDK .NET 6, SQL Server e `dotnet tool install --global dotnet-ef`. A string de conexão padrão usa autenticação integrada do Windows em `localhost`, banco `RAP`. Antes de subir, troque `AppSettings:Token` em `RAP/appsettings.json` por uma chave longa e aleatória (ou defina `AppSettings__Token` e `ConnectionStrings__DefaultConnection`).

```bash
dotnet restore RAP.sln
dotnet ef database update --project Infraestructure --startup-project RAP
dotnet run --project RAP
```

Swagger: https://localhost:7266/swagger (também em http://localhost:5266).

## Limitações

- O `RAP/Dockerfile` ainda aponta para o projeto antigo `Ecommerce-api`; a imagem não acompanha a solução atual.
- `DELETE /api/Batalha/ExcluirBatalha` só devolve mensagem de sucesso. Eventos existem no EF Core sem rota. O projeto `ADTO` (produto e categoria) não entra na solução.
- O MediatR está registrado só no projeto `RAP`; os comandos ficam em `Application`.

## Licença

MIT. Veja [LICENSE](LICENSE).
