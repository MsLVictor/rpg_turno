namespace rpg_turno.Models.Acoes;

using rpg_turno.Interfaces;

public class AtaqueBasico : IAcaoCombate
{
    public string Descricao => "Atacar";

    public void Executar(FichaPersonagem executor, FichaPersonagem alvo)
    {
        int rolarD20Ataque = Dado.RolarD20();
        int rolarD20Defesa = Dado.RolarD20();

        System.Console.WriteLine($"{executor.Nome} rolou {rolarD20Ataque} | {alvo.Nome} Defendeu com {rolarD20Defesa}");

        if (rolarD20Ataque >= 18)
        {
            System.Console.WriteLine("ATAQUE CRÍTICO! Impossível defender!!!");

            alvo.ReceberDano(executor.DanoBase * 2);

            Console.WriteLine($"{executor.DanoBase * 2} de dano!");
        }
        else if (rolarD20Ataque > rolarD20Defesa)
        {
            System.Console.WriteLine("Acerto!");

            executor.Atacar(alvo);

            Console.WriteLine($"{executor.DanoBase} de dano!");
        }
        else
            System.Console.WriteLine("Errou!");

        Thread.Sleep(1000);
    }
}
