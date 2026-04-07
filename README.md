# 🛒 Ecommerce System

aplicação de console em **C# (.NET 8)** que simula um pequeno sistema de e-commerce para fins didáticos.

---

## ✨ Funcionalidades

- 🔐 Login com contas de teste e perfis com descontos
- 📦 Listagem de produtos
- 🛍️ Carrinho de compras (adicionar/remover itens)
- 💳 Fechamento de compra com descontos e frete
- 🥇 Perfis de cliente: Bronze, Silver, Gold

---

## 👤 Contas de Teste

| E-mail               | Senha | Plano  | Benefício                      |
|----------------------|-------|--------|-------------------------------|
| bronze@loja.com      | 123   | Bronze | 10% de desconto               |
| silver@loja.com      | 456   | Silver | 30% de desconto               |
| gold@loja.com        | 789   | Gold   | 30% desc + frete grátis       |

---

## 🛠️ Requisitos

- .NET 8 SDK
- Visual Studio 2026 (ou compatível) ou `dotnet` CLI
- C# 14

---

## 📁 Estrutura do Projeto

```
EcommerceSystem/
├── EcommerceSystem.sln
└── EcommerceSystem/
    ├── Program.cs                 # Menu interativo (entrada)
    ├── GerenciadorLoja.cs         # Lógica principal
    ├── Models/
    │   ├── Produto.cs
    │   ├── Endereco.cs
    │   ├── Cliente.cs
    │   ├── Bronze.cs
    │   ├── Silver.cs
    │   └── Gold.cs
    └── Colecoes/
        ├── Estante.cs
        └── Carrinho.cs
```

---

## ▶️ Como Executar

```bash
# Usando o dotnet CLI
cd EcommerceSystem
 dotnet build
 dotnet run --project EcommerceSystem
```
Ou abra a solução `EcommerceSystem.sln` no Visual Studio e execute o projeto.

---

## 🚦 Uso

1. Faça login com uma conta de teste
2. Visualize produtos
3. Adicione/remova itens do carrinho
4. Feche a compra para ver descontos e frete

---
