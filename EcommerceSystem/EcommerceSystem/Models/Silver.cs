namespace EcommerceSystem.Models
{
    /// <summary>Cliente Silver — 30% de desconto nos produtos.</summary>
    public class Silver : Cliente
    {
        public Silver(string email, string senha) : base(email, senha) { }

        protected override double CalcularDesconto(double valor) => valor * 0.70;

        public override string Categoria => "Silver";
    }
}
