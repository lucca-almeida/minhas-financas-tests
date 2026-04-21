import { describe, it, expect } from 'vitest'
import fs from 'node:fs'

describe('Frontend - UI', () => {
  it('deve conter o título da aplicação no HTML', () => {
    const html = fs.readFileSync(
      'C:/Users/beatr/Downloads/ExameDesenvolvedorDeTestes/ExameDesenvolvedorDeTestes/web/index.html',
      'utf-8'
    )

    expect(html).toContain('<title>web</title>')
  })
})