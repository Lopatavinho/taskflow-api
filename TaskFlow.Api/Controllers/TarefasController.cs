using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs;
using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/tarefas")]
[Authorize]
public class TarefasController : ControllerBase
{
    private readonly ITarefaRepository _repo;

    public TarefasController(ITarefaRepository repo) => _repo = repo;

    private int UserId =>
        int.Parse(User.Claims.First(c => c.Type == "id").Value);

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repo.GetAll(UserId));
    }

    [HttpPost]
    public IActionResult Create(TarefaRequest req)
    {
        var t = new Tarefa
        {
            UsuarioId = UserId,
            Titulo = req.Titulo,
            Descricao = req.Descricao ?? "",
            Status = req.Status ?? "Pendente"
        };

        _repo.Add(t);
        _repo.Save();

        return Ok(t);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TarefaRequest req)
    {
        var t = _repo.Get(id, UserId);
        if (t == null) return NotFound("Tarefa não encontrada.");

        t.Titulo = req.Titulo;
        t.Descricao = req.Descricao ?? "";
        t.Status = req.Status ?? t.Status;

        _repo.Update(t);
        _repo.Save();

        return Ok(t);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var t = _repo.Get(id, UserId);
        if (t == null) return NotFound("Tarefa não encontrada.");

        _repo.Delete(t);
        _repo.Save();

        return Ok("Tarefa excluída.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tarefa = await _repo.GetByIdAsync(id);
        if (tarefa == null)

        return NotFound(new { message = "Tarefa não encontrada." });

        return Ok(tarefa);
    }

}
