using System.Dynamic;

namespace rpg_turno.Models;

public class Mago : FichaPersonagem
{
    public int Mana = 20;
    public override int DanoBase => 10;

    public Mago(string nome) : base(nome, 80) { }

    public override void Atacar(FichaPersonagem alvo)
    {
        alvo.ReceberDano(DanoBase);
        Mana += 5;

        if (Mana > 20)
            Mana = 20;
    }

    public void BolaDeFogo(FichaPersonagem alvo)
    {
        int danoBolaDeFogo = 10 + (int)(DanoBase * 1.8);

        alvo.ReceberDano(danoBolaDeFogo);

        Mana -= 10;
    }

    public override string StatusRecurso => $"Mana: {Mana}/20";
}
