using TaskFlow.Api.Data;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _db;

    public UsuarioRepository(AppDbContext db) => _db = db;

    public Usuario? GetByEmail(string email) =>
        _db.Usuarios.FirstOrDefault(u => u.Email == email);

    public void Add(Usuario u) => _db.Usuarios.Add(u);

    public void Save() => _db.SaveChanges();
}
