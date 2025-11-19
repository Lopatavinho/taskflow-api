using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _db;

    public TarefaRepository(AppDbContext db) => _db = db;

    public List<Tarefa> GetAll(int userId) =>
        _db.Tarefas.Where(t => t.UsuarioId == userId).ToList();

    public Tarefa? Get(int id, int userId) =>
        _db.Tarefas.FirstOrDefault(t => t.Id == id && t.UsuarioId == userId);

    public void Add(Tarefa t) => _db.Tarefas.Add(t);

    public void Update(Tarefa t) => _db.Tarefas.Update(t);

    public void Delete(Tarefa t) => _db.Tarefas.Remove(t);

    public void Save() => _db.SaveChanges();

    public async Task<Tarefa?> GetByIdAsync(int id)
    {
        return await _db.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
    }
}
