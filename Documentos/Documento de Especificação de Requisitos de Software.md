# **Documento de Especificação de Requisitos de Software**

**Luiz Otávio Portes Avelar**

## **Introdução**

Este documento descreve todos os requisitos funcionais e não funcionais do sistema TaskFlow API.

## **Requisitos Funcionais (RF)**

### **RF01: Cadastro de Usuário**

O sistema deve permitir o cadastro de usuários com nome, e-mail e senha.

### **RF02: Login**

O sistema deve permitir que o usuário faça login utilizando e-mail e senha válidos.

### **RF03: Gerar Token JWT**

Ao fazer login, o sistema deve gerar um token JWT com expiração e identificação do usuário.

### **RF04: Listar Tarefas**

O usuário autenticado deve visualizar somente suas tarefas.

### **RF05: Criar Tarefa**

O usuário deve conseguir criar uma nova tarefa contendo: Título, Descrição, Status e Data de Criação.

### **RF06: Buscar Tarefa por ID**

O sistema deve permitir buscar uma tarefa específica do usuário.

### **RF07: Atualizar Tarefa**

Um usuário deve poder atualizar título, descrição e status de uma tarefa.

### **RF08: Excluir Tarefa**

Um usuário deve poder excluir tarefas existentes.

### **RF09: Proteção das Rotas**

Todas as rotas de tarefas devem exigir autenticação JWT.

## **Requisitos Não Funcionais (RNF)**

### **RNF01: Segurança**

O sistema deve utilizar JWT com chave segura de pelo menos 256 bits.

### **RNF02: Desempenho**

A API deve responder em menos de 300 ms em condições normais.

### **RNF03: Manutenibilidade**

O código deve seguir uma arquitetura simples e separada em camadas:

* Controllers

* Repositories

* Models

* DTOs

### **RNF04: Confiabilidade**

Caso o servidor reinicie, os dados devem permanecer armazenados no SQL Server.

### **RNF05: Disponibilidade**

A API deve permanecer acessível enquanto estiver rodando localmente ou em servidor.

### **RNF06: Usabilidade**

Rota Swagger deve ser disponibilizada para testes.

### **RNF07: Portabilidade**

O sistema deve rodar em qualquer sistema operacional com .NET 8\.

