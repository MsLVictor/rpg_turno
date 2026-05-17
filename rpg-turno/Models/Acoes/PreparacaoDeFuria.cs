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
            {
                g.PrepararFuria();
                g.Atacar(alvo);
                Console.WriteLine($"ATAQUE DE FURIA!");
            }
            else
            {
                Console.WriteLine("Fúria insuficiente! Girando os dados para o ataque básico...");

                int rolAtaque = Dado.RolarD20();
                int rolDefesa = Dado.RolarD20();

                Console.WriteLine($"{executor.Nome} rolou {rolAtaque} | {alvo.Nome} defendeu com {rolDefesa}");

                if (rolAtaque >= 18)
                {
                    Console.WriteLine("CRÍTICO! Ataque imparável!");
                    alvo.ReceberDano(executor.DanoBase * 2);
                    Console.WriteLine($"{executor.DanoBase * 2} de dano!");
                }
                else if (rolAtaque > rolDefesa)
                {
                    Console.WriteLine("Acerto!");
                    g.Atacar(alvo);
                    Console.WriteLine($"{executor.DanoBase} de dano!");
                }
                else
                {
                    Console.WriteLine("Errou!");
                }
            }

            Thread.Sleep(1000);
        }
    }
}
