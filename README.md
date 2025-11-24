# 📝 TaskFlow API

API simples para gerenciamento de tarefas com autenticação JWT.  
Inclui cadastro/login de usuários e CRUD completo de tarefas associado ao usuário autenticado.

---

## 🚀 Tecnologias utilizadas

- .NET 8
- ASP.NET Web API
- Entity Framework Core
- SQL Server (Docker)
- JWT Authentication

---

# 📦 Como rodar o projeto em qualquer computador

## ✔️ Pré-requisitos

Antes de começar, instale:

- **.NET 8 SDK**
  https://dotnet.microsoft.com/en-us/download/dotnet/8.0

- **Docker Desktop**
  https://www.docker.com/products/docker-desktop/

- **Git**
  https://git-scm.com/downloads

---

# 📥 1. Clonar o repositório

```bash
git clone https://github.com/Lopatavinho/taskflow-api.git
cd taskflow-api/TaskFlow.Api
🐳 2. Subir o banco SQL Server no Docker

Execute o comando:

bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=TaskFlow@2024" \
   -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
Verifique se está rodando:

bash
docker ps
🗄️ 3. Aplicar as migrations (opcional caso já exista o banco)
Se quiser recriar o banco do zero:

bash
dotnet ef database update
▶️ 4. Rodar a API
bash
dotnet run
Ou pelo Visual Studio / VS Code — basta apertar Run.

A API ficará acessível em:

arduino
http://localhost:5092
Swagger UI:

bash
http://localhost:5092/swagger
🔐 5. Fluxo de autenticação
📌 1. Criar usuário — POST /api/auth/register
Exemplo JSON:

json
{
  "nome": "Luiz",
  "email": "p@gmail.com",
  "senha": "P@123456"
}
📌 2. Fazer login — POST /api/auth/login
json
{
  "email": "p@gmail.com",
  "senha": "P@123456"
}
A resposta terá o token JWT:

json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6..."
}
Copie este token.

🔑 6. Usar o token no Swagger
Abra o Swagger: http://localhost:5092/swagger

Clique em Authorize

Cole o token assim:

nginx
Bearer SEU_TOKEN_AQUI
Clique em Authorize

Agora todas as rotas protegidas funcionarão.

📝 CRUD de Tarefas
✔️ GET /api/tarefas — listar tarefas do usuário
✔️ GET /api/tarefas/{id} — buscar tarefa por ID
✔️ POST /api/tarefas — criar tarefa
✔️ PUT /api/tarefas/{id} — atualizar tarefa
✔️ DELETE /api/tarefas/{id} — excluir tarefa
Todos exigem autenticação JWT.

🗑️ Parar e remover o banco (opcional)
docker stop sqlserver
docker rm sqlserver

📄 Licença

Este projeto é livre para estudo e uso.
