# Desafio Técnico – Sistema de Gestão de Motos e Entregadores

Este repositório contém a implementação de uma API RESTful desenvolvida como parte de um desafio técnico para uma vaga na área de backend. O sistema simula a gestão de motos e entregadores de uma empresa de entregas.

## Tecnologias Utilizadas

- .NET
- C#
- PostgreSQL
- Entity Framework Core
- RabbitMQ
- Swagger

## Funcionalidades Implementadas

- **Motos**
  - Cadastro de nova moto
  - Edição de informações
  - Consulta por ID ou listagem
  - Remoção de moto
  - Geração de eventos para motos com ano de fabricação igual a 2024

- **Entregadores**
  - Cadastro com validações:
    - CNH obrigatória
    - CNPJ único
  - Upload de imagem da CNH
  - Consulta e listagem de entregadores

## Como Executar Localmente
1. Pré-requisitos
Certifique-se de ter instalado:

.NET SDK 8.0+

PostgreSQL (em execução na porta padrão 5432)

RabbitMQ (com Management Plugin ativo, porta 15672)

Pode ser iniciado com o seguinte comando:

bash
docker run -d --hostname rabbit-local --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
Usuário padrão: guest

Senha padrão: guest

Interface Web: http://localhost:15672

2. Clonar o projeto
bash
git clone https://github.com/SEU-USUARIO/Mottu.BackendChallenge.git
cd Mottu.BackendChallenge
3. Configuração do banco de dados
Crie um banco chamado mottu_backend (ou conforme indicado no appsettings.json)

Edite o arquivo appsettings.Development.json e insira sua connection string:

json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=mottu_backend;Username=postgres;Password=postgres"
}
4. Executar as migrations
A partir do diretório do projeto:

bash
dotnet ef database update
5. Executar a aplicação
bash
dotnet run --project Mottu.BackendChallenge
A API será disponibilizada em:

https://localhost:5001/swagger
6. Testar funcionalidades
Use o Swagger para testar endpoints de:

Entregadores
Motos
Locações
Devoluções
Cadastre uma moto e verifique se o evento MotoCriada é publicado na fila moto_criada.

7. Consumidor de eventos da fila
O projeto possui um consumidor que escuta a fila moto_criada. Para rodar:

bash
dotnet run --project Mottu.BackendChallenge.Services.EventConsumer
Esse consumidor:

Escuta eventos no RabbitMQ

Armazena no banco se a moto for do ano 2024

8. Testes de regra de negócio
Os testes foram implementados no próprio projeto. Para executar:

Certifique-se de que o método LocacaoServiceTestsRunner.Run() está habilitado em Program.cs

Rode a aplicação e verifique os resultados no console

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/nome-do-repo.git
   cd nome-do-repo
