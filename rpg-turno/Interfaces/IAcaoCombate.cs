namespace rpg_turno.Interfaces;

using rpg_turno.Models;

public interface IAcaoCombate
{
    string Descricao { get; }

    void Executar(FichaPersonagem executor, FichaPersonagem alvo);
}
