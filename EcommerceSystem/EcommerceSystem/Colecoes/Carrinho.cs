using EcommerceSystem.Models;

namespace EcommerceSystem.Colecoes
{
    /// <summary>
    /// Carrinho de compras do cliente.
    /// </summary>
    public class Carrinho
    {
        public List<Produto> ListaProdutos { get; private set; } = new();

        public void Adicionar(Produto produto)
        {
            ListaProdutos.Add(produto);
        }

        public bool Remover(int index)
        {
            if (index < 0 || index >= ListaProdutos.Count) return false;
            ListaProdutos.RemoveAt(index);
            return true;
        }

        /// <summary>Subtotal sem desconto nem frete.</summary>
        public double SubTotal() =>
            ListaProdutos.Sum(p => p.Preco);

        /// <summary>
        /// Total final já com o desconto e frete do cliente informado.
        /// </summary>
        public double Total(Cliente cliente) =>
            cliente.CalcularTotal(SubTotal());

        public bool EstaVazio => ListaProdutos.Count == 0;

        public void Limpar() => ListaProdutos.Clear();
    }
}
