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

    public static void CriandoPersonagem()
    {
        NarrandoDevagar("Você acorda em um descampado em um local desconhecido para você...");
        Console.Read();
        NarrandoDevagar("Você não lembra de caralho nenhum, O que PORRA aconteceu? - Você pensou...");

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
