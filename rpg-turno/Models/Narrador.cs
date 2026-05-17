using rpg_turno.Interfaces;
using rpg_turno.Models.Factories;

namespace rpg_turno.Models;

public static class Narrador
{

    public static void IniciarJogo()
    {
        Introducao();

        FichaPersonagem jogador = CriandoPersonagem();

        CapituloUm(jogador);

        FichaPersonagem miniOrc = new OrcFactory().CriarPersonagem("Ugluk");

        Luta(jogador, miniOrc);

        if (!jogador.EstaVivo)
            NarrandoLutaPerdida("Você caiu em combate... Léa chora sobre seu corpo frio e desfigurado. GAME OVER.");
        else
            NarrandoLutaGanha("O Inimigo caiu! Você VENCEU!");

    }
    public static void Introducao()
    {
        Console.Clear();

        System.Console.WriteLine(@"
        

        ===== RPGZIN DE TURNO =====
        

        ");

        Thread.Sleep(1000);
        Console.Clear();
        System.Console.WriteLine(@"
        
        
            Desenvolvido por Victor Leite   
        ");
        Thread.Sleep(1500);
        Console.Clear();
        System.Console.WriteLine(@"
        
        
                                        .");
        Thread.Sleep(400);
        Console.Clear();
        System.Console.WriteLine(@"
        
        
                                        ..");
        Thread.Sleep(400);
        Console.Clear();
        System.Console.WriteLine(@"
        
        
                                        ...");
        Thread.Sleep(400);
        Console.Clear();

    }

    public static FichaPersonagem CriandoPersonagem()
    {
        NarrandoDevagar("Você acorda em um descampado em um local desconhecido...");
        Thread.Sleep(500);
        NarrandoDevagar("Você não lembra de car**** nenhum, O que POR** aconteceu? - Pensastes...");
        Thread.Sleep(500);
        NarrandoDevagar("Um barulho em um arbusto próximo... Você se assusta, mas não consegue se mexer direito...");
        Thread.Sleep(500);

        NarrandoDevagarNpcLea(@"
        Uma silhueta de uma pessoa brota no arbusto, uma voz suave te pergunta:
            Está bem viajante?
        Olá, meu nome é Léa, Estava passando, e ouvi você murmurando, Qual o seu nome? ");


        string nome = ValidandoNomePersonagem();

        NarrandoDevagarNpcLea(@$"
        Léa: ""{nome}"" que nome peculiar, e o que você carrega ai nas costas?
        1 - Uma Espada Pesada (GUERREIRO)
        2 - Um Cajado de Madeira (MAGO);
        ");


        var factories = new List<IPersonagemFactory>
        {
            new GuerreiroFactory(),
            new MagoFactory()
        };

        int classe = ValidandoClassePersonagem(factories);

        return factories[classe - 1].CriarPersonagem(nome);
    }

    public static string ValidandoNomePersonagem()
    {
        bool testeNome = true;

        string nome = "";

        while (testeNome)
        {
            nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                NarrandoDevagarNpcLea("Léa: Já que vc n quer falar seu nome, vou lhe chamar de Filho da puta sem nome :D");
                nome = "Filho da puta sem nome";
                testeNome = false;
            }
            else
            {
                NarrandoDevagarNpcLea($"Léa: Seu nome é esse? {nome} tem certeza? s/n");

                string opcaoTemCerteza = Console.ReadLine().ToLower();

                while (opcaoTemCerteza != "s" && opcaoTemCerteza != "n")
                {
                    NarrandoDevagar("Opção inválida! Digite s/n");
                    opcaoTemCerteza = Console.ReadLine().ToLower();
                }

                switch (opcaoTemCerteza)
                {
                    case "s":
                        testeNome = false;
                        break;
                    case "n":
                        break;
                }
            }
        }

        return nome;
    }

    public static int ValidandoClassePersonagem(List<IPersonagemFactory> factories)
    {
        int classe = 0;

        bool testeClasse = true;

        while (testeClasse)
        {
            while (!int.TryParse(Console.ReadLine(), out classe) || classe < 1 || classe > factories.Count)
                NarrandoDevagarNpcLea("Léa: Não entendi, Escolha novamente viajante!");

            string nomeClasse = factories[classe - 1].NomeClasse;

            NarrandoDevagarNpcLea($"Léa: Você é um {nomeClasse}... Tem certeza? s/n");

            string confirma = Console.ReadLine().ToLower();
            switch (confirma)
            {
                case "s":
                    testeClasse = false;
                    break;
                case "n":
                    NarrandoDevagarNpcLea("Léa: Entendido, Pense bem aventureiro, escolha novamente");
                    break;
            }
        }

        return classe;
    }

    public static void CapituloUm(FichaPersonagem heroi)
    {
        string classeNome = heroi is Guerreiro ? "Guerreiro" : "Mago";


        NarrandoDevagarNpcLea(@$"
        Lea: Nossa...
        não vejo muitos de vocês nessas áreas
        O que Você faz por aqui?");


        Console.ForegroundColor = ConsoleColor.Red;
        NarrandoDevagarJogador(@$"
            Fui atacado por alguma criatura estranha, n lembro direito, só sinto que estou ferido.
        ");
        Console.ResetColor();

        NarrandoDevagarNpcLea(@$"
        Lea: Você está péssimo, meu vilarejo é perto daqui.
        Vamos lá pra restaurar suas energias e você seguir viagem.
        ");
        Console.ResetColor();

        NarrandoDevagar($"ao longo de aproximadamento 10 minutos de caminhada depois...");


        NarrandoDevagarNpcLea(@$"
        Léa: Que barulho é esse?
        Droga, é um orc, e vamos ter que enfrentar...
        ");

        Thread.Sleep(500);
        NarrandoDevagar("INICIANDO A LUTA...");
        Thread.Sleep(500);

    }
    public static void NarrandoDevagarNpcLea(string texto)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(30);
        }
        Console.WriteLine("\n");
    }

    public static void NarrandoDevagar(string texto)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(30);
        }
        Console.WriteLine("\n");
    }

    public static void NarrandoDevagarJogador(string texto)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(30);
        }

        Console.WriteLine("\n");
    }

    public static void NarrandoLutaGanha(string texto)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(30);
        }
        Console.WriteLine("\n");
    }

    public static void NarrandoLutaPerdida(string texto)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(30);
        }
        Console.WriteLine("\n");
    }

    public static void Luta(FichaPersonagem p1, FichaPersonagem npc)
    {
        var combate = new Combate();
        combate.IniciarDuelo(p1, npc);
    }
}

