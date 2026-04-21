# BUG 001 - Exclusão em cascata não funciona

## Descrição
Ao excluir uma pessoa, suas transações deveriam ser removidas automaticamente (exclusão em cascata), conforme regra de negócio definida.

## Comportamento atual
As transações permanecem no banco de dados mesmo após a exclusão da pessoa.

## Comportamento esperado
Todas as transações vinculadas à pessoa deveriam ser excluídas automaticamente.

## Evidência 
Teste automatizado:
PessoaIntegrationTests.Deve_remover_transacoes_quando_pessoa_e_excluida

Resultado:
Falha no Assert.Empty, pois ainda existem transações após exclusão da pessoa.

## Impacto 
Dados inconsistentes no sistema, podendo gerar relatórios incorretos e problemas de integridade.

## Possível causa
Relacionamento entre Pessoa e Transacao não está configurado com delete cascade no Entity Framework.