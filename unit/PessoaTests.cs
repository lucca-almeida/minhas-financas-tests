using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests;

public class PessoaTests
{
    [Fact]
    public void Deve_retornar_true_quando_maior_de_idade()
    {
        var pessoa = new Pessoa
        {
            Nome = "Teste",
            DataNascimento = DateTime.Today.AddYears(-20)
        };

        var resultado = pessoa.EhMaiorDeIdade();
        Assert.True(resultado);
    }

    [Fact]
    public void Deve_retornar_false_quando_menor_de_idade()
    {
        var pessoa = new Pessoa
        {
            Nome = "Teste",
            DataNascimento = DateTime.Today.AddYears(-17)
        };

        var resultado = pessoa.EhMaiorDeIdade();
        Assert.False(resultado);
    }

    [Fact]
    public void Deve_retornar_true_quando_tiver_exatamente_18_anos()
    {
        var pessoa = new Pessoa
        {
            Nome = "Limite",
            DataNascimento = DateTime.Today.AddYears(-18)
        };

        var resultado = pessoa.EhMaiorDeIdade();
        Assert.True(resultado);
    }

}