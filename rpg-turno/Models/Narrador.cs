namespace rpg_turno.Models;

public static class Narrador
{
    public static void IniciarJogo()
    {
        Introducao();

        FichaPersonagem jogador = CriandoPersonagem();

        CapituloUm(jogador);

        FichaPersonagem miniOrc = new Orc("Ugluk");

        Luta(jogador, miniOrc);



    }
    public static void Introducao()
    {
        Console.Clear();
        System.Console.WriteLine(@"
        

        ===== RPG DE TURNO VAGABUNDO =====
        

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
        NarrandoDevagar("Você não lembra de caralho nenhum, O que PORRA aconteceu? - Pensastes...");
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

        int classe = ValidandoClassePersonagem();
        string nomeClasse;

        if (classe == 1)
        {
            return new Guerreiro(nome);
            nomeClasse = "Guerreiro";
        }
        else
        {
            return new Mago(nome);
            nomeClasse = "Mago";
        }
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

                switch (opcaoTemCerteza)
                {
                    case "s":
                        testeNome = false;
                        break;

                    case "n":
                        break;
                    default:
                        NarrandoDevagar("Opção inválida! Digite s/n");
                        break;
                }
            }
        }

        return nome;
    }

    public static int ValidandoClassePersonagem()
    {
        int classe = 0;

        bool testeClasse = true;

        while (testeClasse)
        {
            while (!int.TryParse(Console.ReadLine(), out classe) || classe < 1 || classe > 2)
                NarrandoDevagar("Digite uma número válido. 1 ou 2");

            string nomeClasse = (classe == 1) ? "Guerreiro" : "Mago";

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
                default:
                    NarrandoDevagarNpcLea("Léa: Não entendi, Escolha novamente viajante!");
                    break;
            }
        }

        return classe;
    }

    public static void CapituloUm(FichaPersonagem heroi)
    {
        string classeNome = heroi is Guerreiro ? "Guerreiro" : "Mago";


        NarrandoDevagarNpcLea(@$"
        Lea: Nossa, você é um {classeNome}...
        não vejo muitos de vocês nessas áreas
        O que Você faz por aqui?");


        Console.ForegroundColor = ConsoleColor.Red;
        NarrandoDevagarJogador(@$"
            Só sei que nada sei...
        ");
        Console.ResetColor();

        NarrandoDevagarNpcLea(@$"
        Lea: Você está péssimo, meu vilarejo é perto daqui.
        Vamos lá pra restaurar suas energias e você seguir viagem.
        ");
        Console.ResetColor();
        Console.Clear();

        NarrandoDevagar($"5 minutos depois...");
        Console.Clear();

        NarrandoDevagarNpcLea(@$"
        Léa: Que barulho é esse?
        Droga, é um orc, e vamos ter que enfrentar...
        não dá pra fugir...
        ");
        Thread.Sleep(500);
        NarrandoDevagar("INICIANDO A LUTA...");
        Thread.Sleep(500);
        Console.Clear();
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

    public static void Luta(FichaPersonagem p1, FichaPersonagem npc)
    {
        var combate = new Combate();
        combate.IniciarDuelo(p1, npc);
    }
}

