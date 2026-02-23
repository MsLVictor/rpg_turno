namespace rpg_turno.Models;

public class Orc : FichaPersonagem
{
    public Orc(string nome) : base(nome, 100) { }

    public override void Atacar(FichaPersonagem alvo)
    {
        int danoFinal = (Vida < 50) ? 15 : 10;
        alvo.ReceberDano(danoFinal);
    }
}
