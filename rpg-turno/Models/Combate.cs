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

            Console.WriteLine(@$"
            --- Turno de {p1.Nome} - Nv {p1.Nivel} ---
            1 - Atacar
            {(p1 is Guerreiro ? "2 - Preparar Fúria" : "-")}
            0 - Pular Turno
            ");

            while (!int.TryParse(Console.ReadLine(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 2)
                Console.WriteLine("Entrada inválida.");

            switch (opcaoMenu)
            {
                case 1:
                    p1.Atacar(p2);
                    Console.WriteLine($"{p1.Nome} atacou {p2.Nome}");
                    Thread.Sleep(1000);
                    break;

                case 2:
                    if (p1 is Guerreiro g)
                    {
                        if (g.Adrenalina >= 20)
                            g.PrepararFuria();
                        else
                            System.Console.WriteLine("Fúria insuficiente.");

                        g.Atacar(p2);
                        Console.WriteLine($"{p1.Nome} atacou {p2.Nome}");
                    }
                    Thread.Sleep(1000);
                    break;

                case 0:
                    System.Console.WriteLine("Pulando turno");
                    Thread.Sleep(1000);
                    break;
            }

            if (p2.EstaVivo)
            {
                p2.Atacar(p1);
                Console.WriteLine($"{p2.Nome} Atacou {p1.Nome}");
            }
            Thread.Sleep(1000);
        }

        Console.WriteLine($"{(p1.EstaVivo ? $"{p1.Nome} Venceu!" : $"{p2.Nome} Venceu!")}");
        ExibirStatus(p1, p2);
        Thread.Sleep(1000);
    }


    public void ExibirStatus(FichaPersonagem p1, FichaPersonagem p2)
    {
        Console.WriteLine(@$"
        ================== STATUS ==================
        Nv{p1.Nivel} | {p1.Nome}: {p1.Vida} HP | {(p1 is Guerreiro g ? $"{g.Adrenalina}/20" : $"")}
        Nv{p2.Nivel} | {p2.Nome}: {p2.Vida} HP | 
        ============================================
        ");
    }
}