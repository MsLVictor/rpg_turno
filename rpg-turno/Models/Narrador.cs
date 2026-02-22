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
}
