using System.Dynamic;

namespace rpg_turno.Models;

public class Mago : FichaPersonagem
{
    public int Mana { get; private set; } = 20;
    private const int _danoBase = 20;

    public Mago(string nome) : base(nome, 80) { }

    public override void Atacar(FichaPersonagem alvo)
    {
        alvo.ReceberDano(_danoBase);
    }
}
