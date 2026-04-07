using EcommerceSystem.Models;

namespace EcommerceSystem.Colecoes
{
    /// <summary>
    /// Estoque da loja. Inicializa com 10 produtos pré-cadastrados.
    /// </summary>
    public class Estante
    {
        public List<Produto> ListaProdutos { get; private set; }

        public Estante()
        {
            ListaProdutos = new List<Produto>
            {
                new Produto("Notebook Dell Inspiron",   "Eletrônicos",   3_499.90),
                new Produto("Mouse Logitech MX Master", "Periféricos",     299.90),
                new Produto("Teclado Mecânico HyperX",  "Periféricos",     549.90),
                new Produto("Monitor 24\" LG Full HD",  "Eletrônicos",   1_299.90),
                new Produto("Headset Gamer Razer",      "Periféricos",     399.90),
                new Produto("SSD 1TB Kingston",         "Armazenamento",   389.90),
                new Produto("Cadeira Gamer DXRacer",    "Móveis",        1_899.90),
                new Produto("Webcam Logitech C920",     "Periféricos",     499.90),
                new Produto("Hub USB-C 7 portas",       "Acessórios",      149.90),
                new Produto("Mousepad XL RGB",          "Acessórios",       89.90),
            };
        }

        public Produto? BuscarPorIndice(int index)
        {
            if (index >= 0 && index < ListaProdutos.Count)
                return ListaProdutos[index];
            return null;
        }
    }
}
