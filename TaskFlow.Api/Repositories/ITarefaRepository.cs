using TaskFlow.Api.Models;

namespace TaskFlow.Api.Repositories;

public interface ITarefaRepository
{
    List<Tarefa> GetAll(int userId);
    Tarefa? Get(int id, int userId);
    void Add(Tarefa t);
    void Update(Tarefa t);
    void Delete(Tarefa t);
    void Save();
    Task<Tarefa?> GetByIdAsync(int id);

}
