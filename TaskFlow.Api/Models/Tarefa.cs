namespace TaskFlow.Api.Models;

public class Tarefa
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Titulo { get; set; } = "";
    public string? Descricao { get; set; }
    public string Status { get; set; } = "Pendente";
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}
