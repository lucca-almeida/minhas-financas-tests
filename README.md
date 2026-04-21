# Minhas Finanças — Testes Automatizados

Este repositório contém a implementação de testes automatizados para validação das principais regras de negócio do sistema Minhas Finanças, conforme solicitado no teste técnico.

---

## Objetivo

Validar o comportamento do sistema sem alterar o código da aplicação, com foco nas regras de negócio críticas:

- Menor de idade não pode registrar receitas
- Categoria deve respeitar seu tipo (receita / despesa / ambas)
- Exclusão em cascata de transações ao excluir pessoa

---

## Estratégia de Testes

A abordagem segue o conceito de pirâmide de testes, priorizando confiabilidade e velocidade.

Testes Unitários
Validação isolada das regras de negócio, execução rápida e sem dependência externa.

Testes de Integração
Validação entre entidades e persistência utilizando banco em memória.

Testes de Frontend (Vitest)
Validação da estrutura da aplicação React e verificação de elementos HTML essenciais.

Testes End-to-End (Playwright)
Simulação do comportamento real do usuário com a aplicação em execução.

---

## Tecnologias Utilizadas

Backend
- .NET 9
- xUnit
- Entity Framework Core (InMemory)

Frontend
- React + TypeScript
- Vitest
- Playwright

---

## Estrutura do Projeto

MinhasFinancas.Tests
├── unit
│   ├── PessoaTests.cs
│   └── TransacaoTests.cs
├── integration
│   ├── PessoaIntegrationTests.cs
│   └── TransacaoIntegrationTests.cs
├── frontend-tests
│   ├── vitest
│   │   ├── app.test.ts
│   │   ├── app.render.test.ts
│   │   └── app.ui.test.ts
│   ├── e2e
│   │   └── app.e2e.spec.ts
│   ├── package.json
│   ├── tsconfig.json
│   └── playwright.config.ts
├── docs
│   └── bugs.md
└── README.md

---

## Como Rodar os Testes

Backend (unitários e integração)

dotnet test

---

Frontend — Vitest

cd frontend-tests
npx vitest run

---

Frontend — E2E (Playwright)

1. Subir o frontend

cd ExameDesenvolvedorDeTestes/web
npm install
npm run dev

2. Rodar os testes

cd frontend-tests
npx playwright test

---

## Bugs Encontrados

Os bugs identificados estão documentados em:

docs/bugs.md

Bug identificado:

- Exclusão de pessoa não remove transações associadas, violando a regra de exclusão em cascata

---

## Cobertura de Regras de Negócio

Menor de idade não pode ter receita: validado
Categoria respeita tipo: validado
Exclusão em cascata: bug identificado

---

## Decisões Técnicas

- O código da aplicação não foi alterado, conforme exigido
- Os testes foram escritos para evidenciar comportamentos reais
- Backend recebeu maior foco por concentrar as regras de negócio
- Frontend validado com testes estruturais (Vitest) e testes de execução real (Playwright)

---

## Considerações Finais

A solução cobre as principais regras de negócio utilizando diferentes níveis de testes.

A abordagem prioriza clareza, organização, foco nas regras críticas e identificação de falhas reais.

---

## Observação

Este repositório contém apenas os testes, conforme solicitado no enunciado.
O código da aplicação original não foi incluído nem modificado.