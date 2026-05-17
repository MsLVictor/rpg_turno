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
            
            for(int i = 0; i < p1.Acoes.Count; i++)
                Console.WriteLine($"{i + 1} - {p1.Acoes[i].Descricao}");
            
            Console.WriteLine("0 - Pular turno.");

            while (!int.TryParse(Console.ReadLine(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > p1.Acoes.Count)
                Console.WriteLine("Entrada inválida.");

            if(opcaoMenu == 0)
            {
                System.Console.WriteLine("Pulando turno");
                Thread.Sleep(1000);
            }
            else
                p1.Acoes[opcaoMenu - 1].Executar(p1, p2);
            
            
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
        Nv{p1.Nivel} | {p1.Nome}: {p1.Vida} HP | {(p1 is Guerreiro g ? $"Adrenalina {g.Adrenalina}/20" : $"{(p1 is Mago m ? $"Mana: {m.Mana}/20" : "")}")}
        Nv{p2.Nivel} | {p2.Nome}: {p2.Vida} HP | 
        ============================================
        ");
    }
}