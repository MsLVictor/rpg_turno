namespace rpg_turno.Models;

public abstract class FichaPersonagem
{
    public string Nome { get; private set; }
    public int Vida { get; protected set; }
    public int Nivel { get; private set; } = 1;

    public FichaPersonagem(string nome, int vida)
    {
        Nome = nome;
        Vida = vida;
    }

    public abstract void Atacar(FichaPersonagem alvo);

    public void ReceberDano(int dano)
    {
        if (Vida > 0)
            Vida -= dano;

        if (Vida < 0)
            Vida = 0;
    }

    public bool EstaVivo => Vida > 0;
}
