namespace rpg_turno.Models;

public static class Narrador
{
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
        NarrandoDevagar("Você acorda em um descampado em um local desconhecido para você...");
        Thread.Sleep(500);
        NarrandoDevagar("Você não lembra de caralho nenhum, O que PORRA aconteceu? - Você pensou...");
        Thread.Sleep(500);
        NarrandoDevagar("Um barulho em um arbusto próximo... Você se assusta, mas não consigue se mecher direito...");
        Thread.Sleep(500);
        Console.ForegroundColor = ConsoleColor.Cyan;
        NarrandoDevagar(@"Uma silhueta de uma pessoa brota no arbusto, uma voz suave te pergunta: Está bem viajante?
        Olá, meu nome é Léa, Estava passando, e ouvi você murmurando, Qual o seu nome? ");
        Console.ResetColor();

        string nome = ValidandoNomePersonagem();

        NarrandoDevagar(@$"
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

        NarrandoDevagar(@$"Lea: Nossa, você é um {nomeClasse}...");

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
                NarrandoDevagar("Já que vc n quer falar seu nome, vou lhe chamar de Filho da puta sem nome :D");
                nome = "Filho da puta sem nome";
            }
            else
                NarrandoDevagar($"Seu nome é esse? {nome} tem certeza? s/n");

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

            NarrandoDevagar($"Você escolheu {nomeClasse}. Tem certeza? s/n");

            string confirma = Console.ReadLine().ToLower();
            switch (confirma)
            {
                case "s":
                    testeClasse = false;
                    break;
                case "n":
                    NarrandoDevagar("Entendido, Escolha novamente aventureiro!");
                    break;
                default:
                    NarrandoDevagar("Comando não reconhecido, Escolha novamente viajante!");
                    break;
            }
        }

        return classe;
    }

    public static void NarrandoDevagar(string texto)
    {
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(30);
        }
        Console.WriteLine("\n");
    }
}
