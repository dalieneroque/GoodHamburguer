<div align="center">
  
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET" />
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Entity_Framework-7A4BFC?style=flat-square&logo=dotnet&logoColor=white" alt="EF Core" />
  <img src="https://img.shields.io/badge/Blazor-512BD4?style=flat-square&logo=blazor&logoColor=white" alt="Blazor" />
  <img src="https://img.shields.io/badge/Clean_Architecture-6DB33F?style=flat-square&logo=clean-architecture&logoColor=white" alt="Clean Architecture" />
  
  <br />
  <br />

  <h1>🍔 GoodHamburguer API</h1>
  
  <p>
    <strong>Sistema de Gestão de Pedidos para Hamburgueria</strong>
  </p>

  <p>
    API REST completa desenvolvida em .NET 8 com Clean Architecture,<br />
    oferecendo CRUD de pedidos, cálculo inteligente de descontos e cardápio dinâmico.
  </p>

  <br />

  <hr style="width: 50%;" />

  <br />
</div>

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia            | Versão | Finalidade                     |
| --------------------- | ------ | ------------------------------ |
| .NET                  | 8.0    | Framework principal            |
| ASP.NET Core          | 8.0    | Construção da API REST         |
| Entity Framework Core | 8.0    | ORM e acesso a dados           |
| SQL Server            | 2022+  | Banco de dados relacional      |
| Swagger / OpenAPI     | Latest | Documentação interativa da API |
| C#                    | 12.0   | Linguagem de programação       |

---

## ✨ Funcionalidades

✅ **CRUD Completo de Pedidos**
  - Criar, listar, consultar por ID, atualizar e remover pedidos

✅ **Cálculo Automático de Descontos**
  - Regras de negócio aplicadas automaticamente conforme composição do pedido

✅ **Cardápio Dinâmico**
  - Endpoint dedicado para consulta de itens disponíveis e preços

✅ **Validações Robustas**
  - Tratamento claro de erros com mensagens descritivas

✅ **Documentação Interativa**
  - Swagger/OpenAPI configurado para exploração da API

✅ **Persistência em SQL Server**
  - Entity Framework Core com migrations automáticas

---

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture** (Arquitetura Limpa), promovendo:

- 🔹 **Separação de Responsabilidades**: Cada camada tem um propósito bem definido
- 🔹 **Independência de Frameworks**: Domínio isolado de detalhes de infraestrutura
- 🔹 **Testabilidade**: Regras de negócio facilmente testáveis
- 🔹 **Manutenibilidade**: Código organizado e de fácil evolução

---

## 🍽️ Cardápio e Regras

### 📌 Sanduíches

| Item     | Preço  |
|----------|:------:|
| X-Burger | R$ 5,00 |
| X-Egg    | R$ 4,50 |
| X-Bacon  | R$ 7,00 |

### 📌 Acompanhamentos

| Item         | Preço  |
|--------------|:------:|
| Batata Frita | R$ 2,00 |

### 📌 Bebidas

| Item         | Preço  |
|--------------|:------:|
| Refrigerante | R$ 2,50 |

### 🏷️ Regras de Desconto

| Combinação                               | Desconto |
|------------------------------------------|:--------:|
| Sanduíche + Batata Frita + Refrigerante  | **20%**  |
| Sanduíche + Refrigerante                 | **15%**  |
| Sanduíche + Batata Frita                 | **10%**  |

> **Nota**: O pedido permite **apenas um item de cada categoria**. Itens duplicados não são permitidos.

---

## 📡 Endpoints da API

<img width="1920" height="1080" alt="{6898B184-CDC5-49FE-89F0-B30FBC55E6B9}" src="https://github.com/user-attachments/assets/2376de78-5658-4be1-a630-d912513994c2" />


---

## 🚧 Próximos Passos (Em Desenvolvimento)

> **Status do Projeto**: 🟢 **MVP Concluído** | 🟡 **Evolução em Andamento**

O projeto segue em constante evolução! Confira o que está por vir:

### 📋 Roadmap de Desenvolvimento

| Sprint | Funcionalidade | Status | Previsão |
|--------|---------------|:------:|:---------:|
| **Sprint 1** | ✅ API REST Base | Concluído | - |
| **Sprint 1** | ✅ CRUD de Pedidos | Concluído | - |
| **Sprint 1** | ✅ Regras de Desconto | Concluído | - |
| **Sprint 1** | ✅ Endpoint Cardápio | Concluído | - |
| **Sprint 2** | 🚧 Frontend Blazor | Em Progresso | Q2 2026 |
| **Sprint 3** | 🧪 Testes Unitários | Em Progresso | Q2 2026 |


---


<div align="center">

  <h2>👩‍💻 Sobre a Desenvolvedora</h3>

  <a href="https://dalieneroque.github.io/Portifolio/">
    <img src="https://img.shields.io/badge/🌐_Visite_meu_Portfólio_Completo-FF6B6B?style=for-the-badge" alt="Visite meu Portfólio" />
  </a>

  
  
  <p>
    Este projeto foi desenvolvido como parte de um desafio técnico,<br />
    demonstrando habilidades em:
  </p>
  
  <p>
    <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white" alt="C#" />
    <img src="https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET" />
    <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
    <img src="https://img.shields.io/badge/Entity_Framework-7A4BFC?style=flat-square&logo=dotnet&logoColor=white" alt="EF Core" />
    <img src="https://img.shields.io/badge/Blazor-512BD4?style=flat-square&logo=blazor&logoColor=white" alt="Blazor" />
    <img src="https://img.shields.io/badge/Clean_Architecture-6DB33F?style=flat-square&logo=clean-architecture&logoColor=white" alt="Clean Architecture" />
  </p>

  <br />
  

  <br />

  <hr style="width: 60%; border: 1px solid #e0e0e0;" />
  
  
  <p>
    <sub>
      © 2026 GoodHamburguer — Todos os direitos reservados<br />
      Desenvolvido com excelência para o Desafio Técnico .NET
    </sub>
  </p>
</div>





