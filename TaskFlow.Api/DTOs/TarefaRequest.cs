namespace TaskFlow.Api.DTOs;

public record TarefaRequest(string Titulo, string? Descricao, string? Status);
