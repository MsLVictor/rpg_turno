using rpg_turno.Interfaces;
using rpg_turno.Models.Acoes;

namespace rpg_turno.Models.Factories;

public class OrcFactory : IPersonagemFactory
{
    public string NomeClasse => "Orc";

    public List<IAcaoCombate> CriarAcoes() => new()
    {
        new AtaqueBasico()
    };

    public FichaPersonagem CriarPersonagem(string nome)
    {
        var orc = new Orc(nome);

        orc.DefinirAcoes(CriarAcoes());

        return orc;
    }
}
