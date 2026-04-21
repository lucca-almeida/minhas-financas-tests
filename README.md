# MinhasFinancas.Tests

Projeto de testes automatizados criado para validar as principais regras de negócio do sistema *Minhas Finanças*, conforme solicitado no teste técnico.

## Objetivo

Validar o comportamento da aplicação *sem alterar o código-fonte original*, com foco nas regras de negócio descritas no enunciado.

Regras priorizadas:

- menor de idade não pode registrar receitas
- categoria só pode ser usada conforme sua finalidade
- exclusão em cascata de transações ao excluir pessoa

## Tecnologias utilizadas

- *.NET 9*
- *C#*
- *xUnit*
- *Entity Framework Core InMemory* para testes de integração

## Estrutura da pirâmide de testes

### Testes unitários

Responsáveis por validar regras de negócio diretamente nas entidades, de forma rápida e isolada.

Arquivos:
- unit/PessoaTests.cs
- unit/TransacaoTests.cs

Cobertura:
- pessoa maior de idade
- pessoa menor de idade
- pessoa com exatamente 18 anos
- menor de idade não pode registrar receita
- categoria não permite tipo incompatível

### Testes de integração

Responsáveis por validar comportamentos integrados entre entidades e persistência.

Arquivos:
- integration/TransacaoIntegrationTests.cs
- integration/PessoaIntegrationTests.cs

Cobertura:
- criação válida de transação
- bloqueio de receita para menor de idade
- bloqueio de despesa em categoria de receita
- validação da exclusão em cascata ao excluir pessoa

## Como rodar os testes

No terminal, dentro da pasta do projeto:

```bash
dotnet test