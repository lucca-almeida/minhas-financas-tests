using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Infrastructure.Data;
using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests;

public class PessoaIntegrationTests
{
    [Fact]
    public void Deve_remover_transacoes_quando_pessoa_e_excluida()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MinhasFinancasDbContext>()
            .UseInMemoryDatabase(databaseName: "TesteDB")
            .Options;

        using (var context = new MinhasFinancasDbContext(options))
        {
            var pessoa = new Pessoa
            {
                Nome = "Pedro",
                DataNascimento = DateTime.Today.AddYears(-30)
            };

            var transacao = new Transacao
            {
                Descricao = "Pagamento",
                Valor = 1000,
                Tipo = Transacao.ETipo.Receita
            };

            pessoa.Transacoes.Add(transacao);

            context.Pessoas.Add(pessoa);
            context.SaveChanges();

            // Act
            context.Pessoas.Remove(pessoa);
            context.SaveChanges();
        }

        using (var context = new MinhasFinancasDbContext(options))
        {
            // Assert
            var transacoes = context.Transacoes.ToList();

            Assert.Empty(transacoes);
        }
    }
}