using rpg_turno.Interfaces;

namespace rpg_turno.Models.Acoes;

public class PreparacaoDeFuria : IAcaoCombate
{
    public string Descricao => "Ataque furioso";

    public void Executar(FichaPersonagem executor, FichaPersonagem alvo)
    {
        if (executor is Guerreiro g)
        {
            if (g.Adrenalina >= 20)
                g.PrepararFuria();
            else
                Console.WriteLine("Fúria insuficiente.");

            g.Atacar(alvo);
            Console.WriteLine($"{executor.Nome} atacou {alvo.Nome}");
            Thread.Sleep(1000);
        }
    }
}
