import { describe, it, expect } from 'vitest'
import fs from 'node:fs'

describe('Frontend - App', () => {
  it('deve existir o arquivo App.tsx', () => {
    const exists = fs.existsSync(
      'C:/Users/beatr/Downloads/ExameDesenvolvedorDeTestes/ExameDesenvolvedorDeTestes/web/src/App.tsx'
    )

    expect(exists).toBe(true)
  })
})