using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs;
using TaskFlow.Api.Models;
using TaskFlow.Api.Repositories;
using TaskFlow.Api.Services;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioRepository _repo;
    private readonly PasswordHasher _hasher;
    private readonly TokenService _tokens;

    public AuthController(IUsuarioRepository repo, PasswordHasher hasher, TokenService tokens)
    {
        _repo = repo;
        _hasher = hasher;
        _tokens = tokens;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req)
    {
        if (_repo.GetByEmail(req.Email) != null)
            return BadRequest("Email já cadastrado.");

        var novo = new Usuario
        {
            Nome = req.Nome,
            Email = req.Email,
            SenhaHash = _hasher.Hash(req.Senha)
        };

        _repo.Add(novo);
        _repo.Save();

        return Ok("Usuário criado com sucesso.");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req)
    {
        var user = _repo.GetByEmail(req.Email);
        if (user == null) return Unauthorized("Email inválido.");

        if (!_hasher.Verify(req.Senha, user.SenhaHash))
            return Unauthorized("Senha inválida.");

        var token = _tokens.GenerateToken(user.Id);

        return Ok(new { token });
    }
}
