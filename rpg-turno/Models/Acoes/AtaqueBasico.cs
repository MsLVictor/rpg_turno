namespace rpg_turno.Models.Acoes;

using rpg_turno.Interfaces;

public class AtaqueBasico : IAcaoCombate
{
    public string Descricao => "Atacar";

    public void Executar(FichaPersonagem executor, FichaPersonagem alvo)
    {
        executor.Atacar(alvo);

        Console.WriteLine($"{executor.Nome} atacou {alvo.Nome}");
        
        Thread.Sleep(1000);
    }
}
