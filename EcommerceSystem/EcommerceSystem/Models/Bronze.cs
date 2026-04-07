namespace EcommerceSystem.Models
{
    /// <summary>Cliente Bronze — 10% de desconto nos produtos.</summary>
    public class Bronze : Cliente
    {
        public Bronze(string email, string senha) : base(email, senha) { }

        protected override double CalcularDesconto(double valor) => valor * 0.90;

        public override string Categoria => "Bronze";
    }
}
