using rpg_turno.Interfaces;
using rpg_turno.Models.Acoes;

namespace rpg_turno.Models.Factories;

public class MagoFactory : IPersonagemFactory
{
    public string NomeClasse => "Mago";

    public List<IAcaoCombate> CriarAcoes() => new()
    {
        new AtaqueBasico(),
        new LancamentoDeBolaDeFogo()
    };

    public FichaPersonagem CriarPersonagem(string nome)
    {
        var mago = new Mago(nome);

        mago.DefinirAcoes(CriarAcoes());

        return mago;
    }
}
