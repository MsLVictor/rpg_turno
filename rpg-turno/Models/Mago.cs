using System.Dynamic;

namespace rpg_turno.Models;

public class Mago : FichaPersonagem
{
    public int Mana = 20;
    private const int _danoBase = 10;

    public Mago(string nome) : base(nome, 80) { }

    public override void Atacar(FichaPersonagem alvo)
    {
        alvo.ReceberDano(_danoBase);
        Mana += 2;
    }

    public void BolaDeFogo(FichaPersonagem alvo)
    {
        int danoBolaDeFogo = 10 + (int)(_danoBase * 2);
        if (Mana >= 10)
        {
            alvo.ReceberDano(danoBolaDeFogo);
            Mana -= 10;
            Console.WriteLine("Bola de fogo lançada!");
        }
        else
        {
            Console.WriteLine("Mana insuficiente, Lançando ataque básico.");
            Atacar(alvo);
        }

    }
}
