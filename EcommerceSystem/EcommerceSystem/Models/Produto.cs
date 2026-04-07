namespace EcommerceSystem.Models
{
    public class Produto
    {
        public string Nome     { get; private set; }
        public string Categoria { get; private set; }
        public double Preco    { get; private set; }

        public Produto(string nome, string categoria, double preco)
        {
            Nome      = nome;
            Categoria = categoria;
            Preco     = preco;
        }

        public override string ToString() =>
            $"{Nome,-25} | {Categoria,-15} | R$ {Preco,8:F2}";
    }
}
