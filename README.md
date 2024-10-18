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

- [x] Docker instalado

## Instalação

Siga as etapas abaixo para configurar o projeto em sua máquina local:

1. Clone o repositório:
   ```bash
   git clone git@github.com:rfopaulino/paulino-motorbike.git
2. Execute o comando abaixo para rodar o projeto usando docker compose:
   ```bash
   docker compose up -d

## Acesse a Aplicação

Nesta etapa a aplicação já deve estar rodando e poderá ser acessada como mostrado abaixo:

- Documentação da API - http://localhost:8080/swagger/index.html

- RabbitMQ - http://localhost:15672
   - Username = guest
   - Password = guest

_Caso a aplicação não esteja respondendo na porta 8080 repita o comando `docker compose up -d`_

## Permissionamento

Para utilizar as APIs do projeto, é necessário seguir os passos abaixo:

1. **Criar um Usuário**
- Utilize o endpoint `/Account/Register` para criar um novo usuário. Os seguintes dados são necessários:
   - **username**: Nome de usuário desejado
   - **password**: Senha do usuário
   - **role**: Defina o papel do usuário como `admin` ou `driver`
   - **email**: Endereço de e-mail

2. **Gerar um jwt token**
- Após criar o usuário, informe a suas credenciais no endpoint `/Account/Auth` e tenha acesso ao seu token de usuário.

3. **Autenticar**
- O token gerado deve ser utilizado nas requisições subsequentes.
   - Utilize o botão 'Authorize' no topo da tela e armazene o token gerado para usar os endpoints direto pela documentação da API.