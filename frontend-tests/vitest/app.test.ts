import { describe, it, expect } from 'vitest'
import fs from 'node:fs'

describe('Frontend - estrutura básica', () => {
  it('deve conter elemento root no index.html', () => {
    const html = fs.readFileSync(
      'C:/Users/beatr/Downloads/ExameDesenvolvedorDeTestes/ExameDesenvolvedorDeTestes/web/index.html',
      'utf-8'
    )

    expect(html).toContain('<div id="root"></div>')
  })
})