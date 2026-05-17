using rpg_turno.Interfaces;

namespace rpg_turno.Models.Acoes;

public class LancamentoDeBolaDeFogo : IAcaoCombate
{
    public string Descricao => "Bola de fogo";

    public void Executar(FichaPersonagem executor, FichaPersonagem alvo)
    {
        if (executor is Mago m)
        {
            if (m.Mana >= 10)
            {
                m.BolaDeFogo(alvo);
                Console.WriteLine($"BOLA DE FOGO!");
            }
            else
            {
                Console.WriteLine("Mana insuficiente! Partindo para ataque básico...");

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
                    m.Atacar(alvo);
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
