namespace EcommerceSystem.Models
{
    /// <summary>Cliente Gold — 30% de desconto + Frete Grátis.</summary>
    public class Gold : Cliente
    {
        public Gold(string email, string senha) : base(email, senha) { }

        protected override double CalcularDesconto(double valor) => valor * 0.70;

        /// <summary>Gold tem frete grátis independente do endereço.</summary>
        protected override double CalcularFrete() => 0.00;

        public override string Categoria => "Gold";
    }
}
