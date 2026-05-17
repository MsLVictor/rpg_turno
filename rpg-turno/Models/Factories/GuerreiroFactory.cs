using rpg_turno.Interfaces;
using rpg_turno.Models.Acoes;

namespace rpg_turno.Models.Factories;

public class GuerreiroFactory : IPersonagemFactory
{
    public string NomeClasse => "Guerreiro";

    public List<IAcaoCombate> CriarAcoes() => new() 
    {
        new AtaqueBasico(), new PreparacaoDeFuria(),
    };

    public FichaPersonagem CriarPersonagem(string nome)
    {
        var guerreiro = new Guerreiro(nome);
        
        guerreiro.DefinirAcoes(CriarAcoes());

        return guerreiro;
    }

}
