# MinhasFinancas.Tests

Projeto de testes automatizados para validação das principais regras de negócio do sistema *Minhas Finanças*, conforme solicitado no teste técnico.

---

## Objetivo

Validar o comportamento do sistema *sem alterar o código da aplicação*, com foco nas regras de negócio críticas:

- Menor de idade não pode registrar receitas
- Categoria só pode ser usada conforme sua finalidade
- Exclusão em cascata de transações ao excluir pessoa

---

##  Estrutura de Testes

### Unit Tests

Testes rápidos e isolados, focados nas regras de negócio das entidades.

*Arquivos:*
- unit/PessoaTests.cs
- unit/TransacaoTests.cs

*Cobertura:*
- Pessoa maior de idade
- Pessoa menor de idade
- Pessoa com exatamente 18 anos
- Menor de idade não pode registrar receita
- Categoria não permite tipo incompatível

---

### Integration Tests

Testes focados no comportamento integrado entre entidades e persistência de dados.

*Arquivos:*
- integration/TransacaoIntegrationTests.cs
- integration/PessoaIntegrationTests.cs

*Cobertura:*
- Criação válida de transação
- Bloqueio de receita para menor de idade
- Bloqueio de despesa em categoria de receita
- Exclusão em cascata ao excluir pessoa

---

## Bug Identificado

Durante a execução dos testes de integração, foi identificado o seguinte problema:

- Ao excluir uma pessoa, *as transações relacionadas não são removidas*
- Resultado: dados órfãos permanecem no banco

*Comportamento esperado:*
- Exclusão em cascata das transações vinculadas à pessoa

*Comportamento atual:*
- As transações continuam persistidas após a exclusão

Este comportamento foi validado através do teste:

- PessoaIntegrationTests.Deve_remover_transacoes_quando_pessoa_e_excluida

---

## Como rodar os testes

No terminal, dentro da pasta do projeto:

```bash
dotnet test