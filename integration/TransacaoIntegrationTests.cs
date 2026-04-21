using System.Reflection;
using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests;

public class TransacaoIntegrationTests
{
    [Fact]
    public void Deve_permitir_criar_transacao_valida()
    {
        var pessoa = new Pessoa
        {
            Nome = "Pedro",
            DataNascimento = DateTime.Today.AddYears(-30)
        };

        var categoria = new Categoria
        {
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };

        var transacao = new Transacao
        {
            Descricao = "Pagamento",
            Valor = 1000,
            Tipo = Transacao.ETipo.Receita
        };

        var propPessoa = typeof(Transacao).GetProperty("Pessoa");
        propPessoa!.SetValue(transacao, pessoa);

        var propCategoria = typeof(Transacao).GetProperty("Categoria");
        propCategoria!.SetValue(transacao, categoria);

        Assert.Equal(pessoa, transacao.Pessoa);
        Assert.Equal(categoria, transacao.Categoria);
    }

    [Fact]
    public void Nao_deve_permitir_receita_para_menor_de_idade()
    {
        var pessoa = new Pessoa
        {
            Nome = "Menor",
            DataNascimento = DateTime.Today.AddYears(-17)
        };

        var transacao = new Transacao
        {
            Descricao = "Salário",
            Valor = 1000,
            Tipo = Transacao.ETipo.Receita
        };

        var excecao = Assert.Throws<TargetInvocationException>(() =>
        {
            var prop = typeof(Transacao).GetProperty("Pessoa");
            prop!.SetValue(transacao, pessoa);
        });

        Assert.NotNull(excecao.InnerException);
        Assert.IsType<InvalidOperationException>(excecao.InnerException);
        Assert.Equal(
            "Menores de 18 anos não podem registrar receitas.",
            excecao.InnerException.Message);
    }

    [Fact]
    public void Nao_deve_permitir_despesa_em_categoria_de_receita()
    {
        var categoria = new Categoria
        {
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };

        var transacao = new Transacao
        {
            Descricao = "Conta",
            Valor = 200,
            Tipo = Transacao.ETipo.Despesa
        };

        var excecao = Assert.Throws<TargetInvocationException>(() =>
        {
            var prop = typeof(Transacao).GetProperty("Categoria");
            prop!.SetValue(transacao, categoria);
        });

        Assert.NotNull(excecao.InnerException);
        Assert.IsType<InvalidOperationException>(excecao.InnerException);
        Assert.Equal(
            "Não é possível registrar despesa em categoria de receita.",
            excecao.InnerException.Message);
    }
}