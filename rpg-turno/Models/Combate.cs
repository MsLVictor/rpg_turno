namespace rpg_turno.Models;

public class Combate
{

    public void IniciarDuelo(FichaPersonagem p1, FichaPersonagem p2)
    {
        while (p1.EstaVivo && p2.EstaVivo)
        {
            Console.Clear();

            ExibirStatus(p1, p2);

            int opcaoMenu;

            Console.WriteLine($"--- Turno de {p1.Nome} - Nv {p1.Nivel} ---");

            for (int i = 0; i < p1.Acoes.Count; i++)
                Console.WriteLine($"{i + 1} - {p1.Acoes[i].Descricao}");

            Console.WriteLine("0 - Pular turno.");

            while (!int.TryParse(Console.ReadLine(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > p1.Acoes.Count)
                Console.WriteLine("Entrada inválida.");

            if (opcaoMenu == 0)
            {
                Console.WriteLine("Pulando turno");
                Thread.Sleep(2000);
            }
            else
                p1.Acoes[opcaoMenu - 1].Executar(p1, p2);


            if (p2.EstaVivo)
            {
                int rolAtaqueOrc = Dado.RolarD20();
                int rolDefesaJogador = Dado.RolarD20();

                Console.WriteLine($"{p2.Nome} rolou {rolAtaqueOrc} | {p1.Nome} defendeu com {rolDefesaJogador}");

                if (rolAtaqueOrc >= 18)
                {
                    Console.WriteLine("CRÍTICO! Ataque imparável!");
                    p1.ReceberDano(p2.DanoBase * 2);
                    Console.WriteLine($"{p2.DanoBase * 2} de dano!");
                }
                else if (rolAtaqueOrc > rolDefesaJogador)
                {
                    Console.WriteLine("Acerto!");
                    p2.Atacar(p1);
                    Console.WriteLine($"{p2.DanoBase} de dano!");
                }
                else
                {
                    Console.WriteLine($"{p2.Nome} errou!");
                }
            }
            Console.WriteLine("Pressione enter para prosseguir.");
            Console.ReadKey();
        }

        Console.WriteLine($"{(p1.EstaVivo ? $"{p1.Nome} Venceu!" : $"{p2.Nome} Venceu!")}");

        ExibirStatus(p1, p2);

        Console.WriteLine("Pressione enter para prosseguir.");
        
        Console.ReadKey();
    }


    public void ExibirStatus(FichaPersonagem p1, FichaPersonagem p2)
    {
        Console.WriteLine($"============================= STATUS =============================");
        Console.WriteLine($"Nv{p1.Nivel} | {p1.Nome}: {p1.Vida} HP | {p1.StatusRecurso}");
        Console.WriteLine($"Nv{p2.Nivel} | {p2.Nome}: {p2.Vida} HP | {p2.StatusRecurso}");
        Console.WriteLine("===================================================================");
    }
}