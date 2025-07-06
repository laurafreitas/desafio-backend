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

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/nome-do-repo.git
   cd nome-do-repo
