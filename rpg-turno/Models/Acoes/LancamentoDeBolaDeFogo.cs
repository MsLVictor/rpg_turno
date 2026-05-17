using rpg_turno.Interfaces;

namespace rpg_turno.Models.Acoes;

public class LancamentoDeBolaDeFogo : IAcaoCombate
{
    public string Descricao => "Bola de fogo";

    public void Executar(FichaPersonagem executor, FichaPersonagem alvo)
    {
        if (executor is Mago m)
            m.BolaDeFogo(alvo);
    }
}
