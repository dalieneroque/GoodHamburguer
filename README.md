<div align="center">
  
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET" />
  <img src="https://img.shields.io/badge/PostgreSQL-336791?style=flat-square&logo=postgresql&logoColor=white" alt="PostgreSQL" />
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

| Tecnologia            | Finalidade                     |
| --------------------- |------------------------------- |
| .NET                  | Framework principal            |
| ASP.NET Core          | Construção da API REST         |
| Entity Framework Core | ORM e acesso a dados           |
| PostgreSQL            | Banco de dados relacional      |
| Swagger / OpenAPI     | Documentação interativa da API |
| C#                    | Linguagem de programação       |
| Blazor WebAssembly    | Frontend                       |

---

## ✨ Funcionalidades

✅ **CRUD Completo de Pedidos**

✅ **Cálculo Automático de Descontos**

✅ **Cardápio Dinâmico**

✅ **Validações e regras de negócio**

✅ **Documentação interativa com Swagger**

✅ **Persistência com PostgreSQL + EF Core**

---

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture** (Arquitetura Limpa), promovendo:

- **Separação de Responsabilidades**
- **Independência de Frameworks**
- **Alta Testabilidade**
- **Facilidade de manutenção e evolução**

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

## Frontend em Blazor

<img width="1142" height="561" alt="Design sem nome" src="https://github.com/user-attachments/assets/c726ffe7-1292-499c-8fdf-04b39d496656" />


---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para rodar a API `GoodHamburguer` em seu ambiente local.

### Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (versão 13 ou superior)
- [Git](https://git-scm.com/) (para clonar o repositório)
- Um editor de código (recomendado: [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/) ou [VS Code](https://code.visualstudio.com/))

### Clonar o Repositório

`git clone https://github.com/dalieneroque/GoodHamburguer.git`

`cd GoodHamburguer`

### Configurar a String de Conexão (PostgreSQL)

Abra o arquivo `appsettings.json` localizado na pasta `GoodHamburguer.Api`

Localize a seção `"ConnectionStrings"` e ajuste a string de conexão para o seu PostgreSQL:

`"ConnectionStrings": { "DefaultConnection": "Host=localhost;Database=GoodHamburguerDB;Username=SEU_USUARIO;Password=SUA_SENHA" }`

### Executar a API

A partir da pasta raiz do projeto, execute:

`cd GoodHamburguer.Api`

`dotnet run`

Após a execução, você verá algo como:

`Now listening on: http://localhost:5xxx`

`Now listening on: https://localhost:7xxx`

---

## 🚧 Próximos Passos (Em Desenvolvimento)

> **Status do Projeto**: 🟢 **MVP Concluído** | 🟡 **Evolução em Andamento**

### 📋 Roadmap de Desenvolvimento

| Sprint | Funcionalidade | Status | Previsão |
|--------|---------------|:------:|:---------:|
| **Sprint 1** | ✅ API REST Base | Concluído | - |
| **Sprint 1** | ✅ CRUD de Pedidos | Concluído | - |
| **Sprint 1** | ✅ Regras de Desconto | Concluído | - |
| **Sprint 1** | ✅ Endpoint Cardápio | Concluído | - |
| **Sprint 2** | ✅ Frontend Blazor | Concluído | - |
| **Sprint 3** | 🧪 Testes Unitários | Em Progresso | - |


---

## 📄 Licença

© 2026 GoodHamburguer — Projeto para fins educacionais e avaliação técnica.

---


<div align="center">

  <h2>👩‍💻 Sobre a Desenvolvedora</h3>

  <a href="https://dalieneroque.github.io/Portifolio/">
    <img src="https://img.shields.io/badge/🌐_Visite_meu_Portfólio_Completo-FF6B6B?style=for-the-badge" alt="Visite meu Portfólio" />
  </a>

  
  
  <p>
    Este projeto foi desenvolvido como parte de um desafio técnico.
  </p>
  

  <hr style="width: 60%; border: 1px solid #e0e0e0;" />
  
  
  





