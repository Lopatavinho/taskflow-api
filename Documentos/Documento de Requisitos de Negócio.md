## **Documento de Requisitos de Negócio**

**Luiz Otávio Portes Avelar**

## **Visão Geral do Projeto**

O sistema TaskFlow API é uma API de gerenciamento de tarefas com autenticação JWT, permitindo que usuários cadastrem tarefas pessoais e realizem operações de CRUD de forma segura. O objetivo principal é oferecer uma solução simples e eficaz para organizar atividades.

## **Objetivo do Negócio**

* Facilitar o gerenciamento pessoal de tarefas.

* Garantir segurança no acesso às informações do usuário.

* Permitir que usuários acompanhem, atualizem e organizem suas tarefas.

* Reduzir o uso de planilhas e anotações manuais.

## **Problema de Negócio**

Usuários precisam organizar suas tarefas diárias, mas não possuem um sistema seguro e centralizado para gerenciar atividades em diferentes dispositivos.

## **Escopo do Negócio**

O sistema deve permitir:

* Autenticação segura de usuários.

* Criação e organização de tarefas pessoais.

* Restrição de acesso: cada usuário vê apenas suas próprias tarefas.

* Manipulação completa do ciclo de vida das tarefas.

## 

## **Stakeholders**

|  Stakeholder  |           Papel           |             Necessidades               |
|     ---->     |           ---->           |                 ---->                  |
| Usuário Final |       Utiliza a API       |  Gerenciar suas Tarefas com Segurança  |
| Desenvolvedor | Mantém e Evolui o Sistema |      Arquitetura Simples e Segura      |
| Administrador | Gerencia a Infraestrutura | Ambiente estável, logs e monitoramento |

## **Regras de Negócio**

1. Cada usuário só pode visualizar e manipular suas próprias tarefas.

2. O login só é permitido com credenciais válidas.

3. O token JWT deve ser válido para acessar qualquer rota protegida.

4. Tarefas devem obrigatoriamente ter um título.

5. O status deve ser sempre um dos valores: Pendente, Em Progresso, Concluída.

6. Uma tarefa não pode ser criada sem um usuário autenticado.

7. Todas as operações devem registrar a tarefa vinculada ao “UsuarioId”.

---

## **Critérios de Sucesso do Negócio**

* Usuário consegue se cadastrar e fazer login com sucesso.

* Todas as operações CRUD funcionam somente após autenticação.

* Nenhum usuário consegue ver as tarefas de outro.

* Sistema estável, simples e documentado.