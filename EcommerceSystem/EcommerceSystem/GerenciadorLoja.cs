using EcommerceSystem.Colecoes;
using EcommerceSystem.Models;

namespace EcommerceSystem
{
    public class GerenciadorLoja
    {
        public Cliente? Cliente  { get; private set; }
        public Estante  Produtos { get; private set; }
        public Carrinho Carrinho { get; private set; }

        // Banco simulado de clientes cadastrados
        private readonly List<Cliente> _clientesCadastrados;

        public GerenciadorLoja()
        {
            Produtos = new Estante();
            Carrinho = new Carrinho();

            _clientesCadastrados = new List<Cliente>
            {
                new Bronze("bronze@loja.com", "123") { Endereco = new Endereco("Votorantim", "SP") },
                new Silver("silver@loja.com", "456") { Endereco = new Endereco("São Paulo",  "SP") },
                new Gold  ("gold@loja.com",   "789") { Endereco = new Endereco("Curitiba",   "PR") },
            };
        }

        // ── LogarCliente ─────────────────────────────────────────────────────
        public bool LogarCliente(string email, string senha)
        {
            var c = _clientesCadastrados
                .FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (c != null && c.ValidarSenha(senha))
            {
                Cliente = c;
                Carrinho.Limpar();   // novo login → carrinho zerado
                return true;
            }
            return false;
        }

        public void Deslogar()
        {
            Cliente = null;
            Carrinho.Limpar();
        }

        // ── MostrarProdutos ───────────────────────────────────────────────────
        public void MostrarProdutos()
        {
            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   PRODUTOS DISPONÍVEIS                ║");
            Console.WriteLine("╠═══╦═══════════════════════════╦═════════════╦══════════╣");
            Console.WriteLine("║ # ║ Nome                      ║ Categoria   ║ Preço    ║");
            Console.WriteLine("╠═══╬═══════════════════════════╬═════════════╬══════════╣");

            for (int i = 0; i < Produtos.ListaProdutos.Count; i++)
            {
                var p = Produtos.ListaProdutos[i];
                Console.WriteLine($"║{i + 1,2} ║ {p.Nome,-25} ║ {p.Categoria,-11} ║ R${p.Preco,7:F2} ║");
            }
            Console.WriteLine("╚═══╩═══════════════════════════╩═════════════╩══════════╝");
        }

        // ── AdicionarCarrinho ────────────────────────────────────────────────
        public bool AdicionarCarrinho(int indexProduto)
        {
            var produto = Produtos.BuscarPorIndice(indexProduto);
            if (produto == null) return false;
            Carrinho.Adicionar(produto);
            return true;
        }

        // ── RemoverProduto ───────────────────────────────────────────────────
        public bool RemoverProduto(int indexCarrinho) =>
            Carrinho.Remover(indexCarrinho);

        // ── FecharCompra ─────────────────────────────────────────────────────
        public void FecharCompra()
        {
            if (Cliente == null)
            {
                Console.WriteLine("⚠  Faça login para finalizar a compra.");
                return;
            }
            if (Carrinho.EstaVazio)
            {
                Console.WriteLine("⚠  O carrinho está vazio.");
                return;
            }

            double subTotal = Carrinho.SubTotal();
            double total    = Carrinho.Total(Cliente);
            double desconto = subTotal - (total - (Cliente is Gold ? 0 : Cliente.Endereco?.CalcularFrete() ?? 50));
            double frete    = Cliente is Gold ? 0 : Cliente.Endereco?.CalcularFrete() ?? 50;

            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║              RESUMO DA COMPRA              ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine($"║  Cliente  : {Cliente.Email,-30}║");
            Console.WriteLine($"║  Plano    : {Cliente.Categoria,-30}║");
            Console.WriteLine($"║  Endereço : {Cliente.Endereco,-30}║");
            Console.WriteLine("╠════════════════════════════════════════════╣");

            foreach (var p in Carrinho.ListaProdutos)
                Console.WriteLine($"║  {p.Nome,-25} R$ {p.Preco,8:F2}   ║");

            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine($"║  Subtotal          : R$ {subTotal,12:F2}       ║");

            if (Cliente is Bronze)
                Console.WriteLine($"║  Desconto (10%)    : R$ {subTotal * 0.10,12:F2}       ║");
            else if (Cliente is Silver)
                Console.WriteLine($"║  Desconto (30%)    : R$ {subTotal * 0.30,12:F2}       ║");
            else if (Cliente is Gold)
                Console.WriteLine($"║  Desconto (30%)    : R$ {subTotal * 0.30,12:F2}       ║");

            Console.WriteLine($"║  Frete             : R$ {frete,12:F2}       ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine($"║  TOTAL             : R$ {total,12:F2}       ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Carrinho.Limpar();
            Console.WriteLine("\n✅ Compra realizada com sucesso! Carrinho esvaziado.\n");
        }

        // ── Mostrar carrinho ─────────────────────────────────────────────────
        public void MostrarCarrinho()
        {
            Console.WriteLine();
            if (Carrinho.EstaVazio)
            {
                Console.WriteLine("  Carrinho vazio.");
                return;
            }

            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                 MEU CARRINHO                   ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");

            for (int i = 0; i < Carrinho.ListaProdutos.Count; i++)
            {
                var p = Carrinho.ListaProdutos[i];
                Console.WriteLine($"║  [{i + 1}] {p.Nome,-28} R$ {p.Preco,7:F2}  ║");
            }

            Console.WriteLine($"╠════════════════════════════════════════════════╣");
            Console.WriteLine($"║  Subtotal: R$ {Carrinho.SubTotal(),10:F2}                        ║");
            if (Cliente != null)
                Console.WriteLine($"║  Total c/ desc.+frete: R$ {Carrinho.Total(Cliente),10:F2}              ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
        }
    }
}
