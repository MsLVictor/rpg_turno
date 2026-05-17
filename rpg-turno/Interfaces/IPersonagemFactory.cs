namespace rpg_turno.Interfaces;

using rpg_turno.Models;

public interface IPersonagemFactory
{
    string NomeClasse { get; }
    FichaPersonagem CriarPersonagem(string nome);
    List<IAcaoCombate> CriarAcoes();
}
