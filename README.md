# MinhasFinancas.Tests

Projeto de testes automatizados para validação das principais regras de negócio do sistema *Minhas Finanças*, conforme solicitado no teste técnico.

## Objetivo

Validar o comportamento do sistema sem alterar o código da aplicação, com foco nas regras de negócio mais importantes:

- menor de idade não pode registrar receitas
- categoria só pode ser usada conforme sua finalidade
- exclusão em cascata de transações ao excluir pessoa

## Estrutura da pirâmide de testes

### Unit
Testes rápidos e focados nas regras de negócio das entidades.

Arquivos:
- unit/PessoaTests.cs
- unit/TransacaoTests.cs

Cobertura principal:
- pessoa maior de idade
- pessoa menor de idade
- pessoa com exatamente 18 anos
- menor de idade não pode registrar receita
- categoria não permite tipo incompatível

### Integration
Testes com foco no comportamento integrado entre entidades e persistência.

Arquivos:
- integration/TransacaoIntegrationTests.cs
- integration/PessoaIntegrationTests.cs

Cobertura principal:
- criação válida de transação
- bloqueio de receita para menor de idade
- bloqueio de despesa em categoria de receita
- exclusão em cascata ao excluir pessoa

## Como rodar os testes

No terminal, dentro da pasta do projeto de testes:

```bash
dotnet test