namespace EcommerceSystem.Models
{
    public class Cliente
    {
        public  string   Email    { get; set; }
        private string   _senha;
        public  Endereco Endereco { get; set; }

        public Cliente(string email, string senha)
        {
            Email  = email;
            _senha = senha;
        }

        public bool ValidarSenha(string senha) => _senha == senha;

        /// <summary>Retorna o valor com desconto aplicado (sobrescrito em subclasses).</summary>
        protected virtual double CalcularDesconto(double valor) => valor; // sem desconto

        /// <summary>Retorna o valor do frete com base no endereço (Gold sobrescreve para 0).</summary>
        protected virtual double CalcularFrete() =>
            Endereco?.CalcularFrete() ?? 50.00;

        public double CalcularTotal(double subTotal) =>
            CalcularDesconto(subTotal) + CalcularFrete();

        public virtual string Categoria => "Sem categoria";

        public override string ToString() => $"[{Categoria}] {Email}";
    }
}
