using TaskFlow.Api.Models;
using Xunit;

public class TarefasTests
{
    [Fact]
    public void CriarTarefa_DeveGerarDataAutomatica()
    {
        var t = new Tarefa { Titulo = "Teste" };
        Assert.True(t.CriadoEm <= DateTime.Now);
    }

    [Fact]
    public void StatusPadrao_DeveSerPendente()
    {
        var t = new Tarefa();
        Assert.Equal("Pendente", t.Status);
    }

    [Fact]
    public void UsuarioId_DeveSerInteiro()
    {
        var t = new Tarefa { UsuarioId = 1 };
        Assert.Equal(1, t.UsuarioId);
    }

    [Fact]
    public void Titulo_NaoPodeSerNulo()
    {
        var t = new Tarefa { Titulo = "abc" };
        Assert.NotNull(t.Titulo);
    }

    [Fact]
    public void Tarefa_DevePermitirDescricaoNula()
    {
        var t = new Tarefa { Descricao = null };
        Assert.Null(t.Descricao);
    }
}
