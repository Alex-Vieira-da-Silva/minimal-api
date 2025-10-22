# 🚀 Minimal API - Autenticação de Administradores


## 🧠 Visão Geral da Arquitetura

A aplicação é composta por uma API principal que realiza autenticação via login de administradores, persistência de dados com Entity Framework Core e suporte a CORS para integração com frontends externos. O Nginx atua como proxy reverso para roteamento de requisições.

---

## 🔄 Fluxo de Comunicação

1. O cliente envia uma requisição de login para o Nginx.  
2. O Nginx redireciona para a API Minimalista na porta 5001.  
3. A API valida as credenciais do administrador.  
4. Se válidas, retorna os dados ou token de autenticação.  
5. Todas as informações são persistidas em um banco de dados relacional.
6. 
---
### 🧩 Componentes Principais

| Componente              | Responsabilidades                                                                 |
|-------------------------|-----------------------------------------------------------------------------------|
| **Cliente**             | Interface de interação com a API (navegador, app ou sistema externo).            |
| **API Minimalista**     | Autenticação de administradores, persistência de dados, exposição de endpoints.  |
| **Entity Framework**    | ORM para abstração de acesso ao banco de dados relacional.                       |
| **Nginx**               | Proxy reverso para roteamento e segurança.                                       |
| **Banco de Dados**      | Armazenamento estruturado de credenciais e dados administrativos.                |

---

## ⚠️ Observações Importantes

- A API está configurada para rodar na porta **5001**.
- O Nginx deve ser configurado para redirecionar requisições da porta 80 para `localhost:5001`.
- CORS está liberado para qualquer origem durante o desenvolvimento.
- Certifique-se de que o `dotnet-ef` está instalado globalmente:
  ```bash
  dotnet tool install --global dotnet-ef --version 9.0.9
  export PATH="$PATH:$HOME/.dotnet/tools"

---

## 🧰 Tecnologias

- .NET 9.0.9 SDK
- Entity Framework Core
- MySQL ou PostgreSQL
- CORS habilitado
- Nginx (proxy reverso)
- dotnet-ef CLI

---

## 📦 Instalação

```bash
git clone https://github.com/seu-usuario/minimal-api.git
cd minimal-api/Api
dotnet restore
