using TaskFlow.Api.Models;

namespace TaskFlow.Api.Repositories;

public interface IUsuarioRepository
{
    Usuario? GetByEmail(string email);
    void Add(Usuario u);
    void Save();
}
