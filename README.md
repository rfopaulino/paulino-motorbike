# Paulino Motorbike

Aplicação para gerenciar aluguel de motos e entregadores.

## Tecnologias Utilizadas

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Dapper](https://github.com/DapperLib/Dapper)
- [Mediatr](https://github.com/jbogard/MediatR)
- [RabbitMQ](https://www.rabbitmq.com/)
- [PostgreSQL](https://www.postgresql.org/)
- [FluentValidation](https://docs.fluentvalidation.net/)
- [xUnit](https://xunit.net/)
- [AspNetCore.Identity](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- [x] .NET 8.0 instalado
- [x] Docker instalado

## Instalação

Siga as etapas abaixo para configurar o projeto em sua máquina local:

1. Clone o repositório:
   ```bash
   git clone git@github.com:rfopaulino/paulino-motorbike.git
2. Execute o comando abaixo para rodar o projeto usando docker compose:
   ```bash
   docker compose up -d

Feito isso o projeto estará rodando em http://localhost:8080/swagger/index.html