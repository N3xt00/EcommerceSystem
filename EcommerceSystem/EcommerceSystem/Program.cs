using EcommerceSystem;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var loja = new GerenciadorLoja();

// ─── helpers ─────────────────────────────────────────────────────────────────
void Cabecalho()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════╗");
    Console.WriteLine("║        🛒  ECOMMERCE SYSTEM  🛒          ║");
    Console.WriteLine("╚══════════════════════════════════════════╝");
    Console.ResetColor();

    if (loja.Cliente != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Logado como: {loja.Cliente}");
        Console.ResetColor();
    }
    Console.WriteLine();
}

void Pausar()
{
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey(true);
}

int LerInt(string prompt)
{
    Console.Write(prompt);
    int.TryParse(Console.ReadLine(), out int v);
    return v;
}

// ─── fluxo de login ───────────────────────────────────────────────────────────
void TelaLogin()
{
    Cabecalho();
    Console.WriteLine("  ── LOGIN ──────────────────────────────────");
    Console.WriteLine("  Contas de teste:");
    Console.WriteLine("    bronze@loja.com  /  123  (Bronze - 10% desc)");
    Console.WriteLine("    silver@loja.com  /  456  (Silver - 30% desc)");
    Console.WriteLine("    gold@loja.com    /  789  (Gold   - 30% + frete grátis)");
    Console.WriteLine();
    Console.Write("  E-mail : "); string email = Console.ReadLine() ?? "";
    Console.Write("  Senha  : "); string senha = Console.ReadLine() ?? "";

    if (loja.LogarCliente(email, senha))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✅ Login efetuado! Bem-vindo(a), {loja.Cliente}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n  ❌ E-mail ou senha incorretos.");
        Console.ResetColor();
    }
    Pausar();
}

// ─── menu principal ───────────────────────────────────────────────────────────
bool sair = false;
while (!sair)
{
    Cabecalho();
    Console.WriteLine("  MENU PRINCIPAL");
    Console.WriteLine("  ─────────────────────────────────────────");

    if (loja.Cliente == null)
    {
        Console.WriteLine("  [1] Logar");
        Console.WriteLine("  [0] Sair");
        Console.Write("\n  Opção: ");
        switch (Console.ReadLine())
        {
            case "1": TelaLogin(); break;
            case "0": sair = true;  break;
        }
    }
    else
    {
        Console.WriteLine("  [1] Ver produtos");
        Console.WriteLine("  [2] Ver carrinho");
        Console.WriteLine("  [3] Adicionar produto ao carrinho");
        Console.WriteLine("  [4] Remover produto do carrinho");
        Console.WriteLine("  [5] Fechar compra");
        Console.WriteLine("  [6] Deslogar");
        Console.WriteLine("  [0] Sair");
        Console.Write("\n  Opção: ");

        switch (Console.ReadLine())
        {
            case "1":
                Cabecalho();
                loja.MostrarProdutos();
                Pausar();
                break;

            case "2":
                Cabecalho();
                loja.MostrarCarrinho();
                Pausar();
                break;

            case "3":
                Cabecalho();
                loja.MostrarProdutos();
                int idx = LerInt("\n  Número do produto: ") - 1;
                if (loja.AdicionarCarrinho(idx))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  ✅ Produto adicionado ao carrinho!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  ❌ Produto inválido.");
                    Console.ResetColor();
                }
                Pausar();
                break;

            case "4":
                Cabecalho();
                loja.MostrarCarrinho();
                if (!loja.Carrinho.EstaVazio)
                {
                    int rem = LerInt("\n  Número do item a remover: ") - 1;
                    if (loja.RemoverProduto(rem))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  ✅ Item removido.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  ❌ Item inválido.");
                        Console.ResetColor();
                    }
                }
                Pausar();
                break;

            case "5":
                Cabecalho();
                loja.FecharCompra();
                Pausar();
                break;

            case "6":
                loja.Deslogar();
                Console.WriteLine("  Sessão encerrada.");
                Pausar();
                break;

            case "0":
                sair = true;
                break;
        }
    }
}

Console.WriteLine("\n  Até logo! 👋\n");
