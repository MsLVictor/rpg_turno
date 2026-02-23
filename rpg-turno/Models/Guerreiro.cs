namespace rpg_turno.Models;

public class Guerreiro : FichaPersonagem
{
    public int Adrenalina { get; private set; } = 0;

    private const int _AdrenalinaMaxima = 20;
    private const int _GanhoAdrenalina = 5;
    private const int _DanoBase = 10;

    private bool _FuriaPretendida = false;

    public Guerreiro(string nome) : base(nome, 120) { }

    public override void Atacar(FichaPersonagem alvo)
    {
        if (_FuriaPretendida && Adrenalina >= _AdrenalinaMaxima)
        {
            HabilidadeFuria(alvo);
            _FuriaPretendida = false;
            return;
        }

        AtaqueNormal(alvo);
        _FuriaPretendida = false;
    }

    public void PrepararFuria()
    {
        if (Adrenalina >= _AdrenalinaMaxima)
            _FuriaPretendida = true;
    }

    public void AtaqueNormal(FichaPersonagem alvo)
    {
        alvo.ReceberDano(_DanoBase);

        Adrenalina += _GanhoAdrenalina;
    }

    private void HabilidadeFuria(FichaPersonagem alvo)
    {
        int danoComBonus = (int)(_DanoBase * 1.20);

        alvo.ReceberDano(danoComBonus);
        alvo.ReceberDano(danoComBonus);
        alvo.ReceberDano(danoComBonus);

        Adrenalina = 0;
    }
}
