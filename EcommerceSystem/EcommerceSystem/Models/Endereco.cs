namespace EcommerceSystem.Models
{
    public class Endereco
    {
        private string Cidade { get; set; }
        private string Estado { get; set; }

        public Endereco(string cidade, string estado)
        {
            Cidade = cidade;
            Estado = estado;
        }

        /// <summary>
        /// Votorantim → R$ 10,00 | SP → R$ 30,00 | Outros → R$ 50,00
        /// </summary>
        public double CalcularFrete()
        {
            if (Cidade.Equals("Votorantim", StringComparison.OrdinalIgnoreCase))
                return 10.00;
            if (Estado.Equals("SP", StringComparison.OrdinalIgnoreCase))
                return 30.00;
            return 50.00;
        }

        public override string ToString() => $"{Cidade} - {Estado}";
    }
}
