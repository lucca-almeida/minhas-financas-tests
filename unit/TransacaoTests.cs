using System.Reflection;
using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests;

public class TransacaoTests
{
    [Fact]
    public void Deve_lancar_excecao_quando_menor_de_idade_tentar_registrar_receita()
    {
        var pessoa = new Pessoa
        {
            Nome = "Menor",
            DataNascimento = DateTime.Today.AddYears(-17)
        };

        var transacao = new Transacao
        {
            Descricao = "Salário",
            Valor = 100,
            Tipo = Transacao.ETipo.Receita
        };

        var excecao = Assert.Throws<TargetInvocationException>(() =>
        {
            var propriedade = typeof(Transacao).GetProperty("Pessoa");
            propriedade!.SetValue(transacao, pessoa);
        });

        Assert.NotNull(excecao.InnerException);
        Assert.IsType<InvalidOperationException>(excecao.InnerException);
        Assert.Equal("Menores de 18 anos não podem registrar receitas.", 
        excecao.InnerException.Message);
    }
    

[Fact]
public void Deve_permitir_lancar_excecao_quando_categoria_nao_permite__tipo()
    {
        //Arrange
        var categoria = new Categoria
        {
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };

        var transacao = new Transacao
        {
            Descricao = "Conta de luz",
            Valor = 200,
            Tipo = Transacao.ETipo.Despesa
        };

        //Act
        var excecao = Assert.Throws<TargetInvocationException>(()=>
        {
            var propriedade = typeof(Transacao).GetProperty("Categoria");
            propriedade!.SetValue(transacao, categoria);
        });

        //Assert 
        Assert.NotNull(excecao.InnerException);
        Assert.IsType<InvalidOperationException>(excecao.InnerException);
        Assert.Equal(
            "Não é possível registrar despesa em categoria de receita.",
            excecao.InnerException.Message);
    }
}