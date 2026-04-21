import { test, expect } from '@playwright/test'

test('deve carregar a página inicial e exibir conteúdo', async ({ page }) => {
  await page.goto('http://localhost:5173/')

  // Espera a página carregar
  await page.waitForLoadState('domcontentloaded')

  // Verifica se existe algum texto visível na página
  const body = await page.locator('body').textContent()

  expect(body).not.toBeNull()
  expect(body!.length).toBeGreaterThan(10)
})