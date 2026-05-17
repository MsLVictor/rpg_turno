# Padrões de Projeto Utilizados

Este projeto aplica dois padrões de projeto clássicos do livro *Design Patterns* (Gang of Four): **Strategy** e **Abstract Factory**.

---

## Strategy

### O que é
Define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. Permite que o algoritmo varie independentemente dos clientes que o utilizam.

### Como foi aplicado
As ações de combate (`AtaqueBasico`, `PreparacaoDeFuria`, `LancamentoDeBolaDeFogo`) implementam a interface `IAcaoCombate`:

```csharp
public interface IAcaoCombate
{
    string Descricao { get; }
    void Executar(FichaPersonagem executor, FichaPersonagem alvo);
}
```

O `Combate` não sabe qual ação está sendo executada — ele só chama `Executar()`. Isso permite adicionar novas ações sem modificar a classe `Combate`.

### Estrutura no projeto
```
Interfaces/
  IAcaoCombate.cs
Models/Acoes/
  AtaqueBasico.cs
  PreparacaoDeFuria.cs
  LancamentoDeBolaDeFogo.cs
```

---

## Abstract Factory

### O que é
Fornece uma interface para criar famílias de objetos relacionados sem especificar suas classes concretas. Diferente do Factory Method (que cria um único produto), o Abstract Factory cria múltiplos produtos que andam juntos.

### Como foi aplicado
A `IPersonagemFactory` define dois métodos de criação — um personagem e suas ações são produtos de uma mesma família:

```csharp
public interface IPersonagemFactory
{
    string NomeClasse { get; }
    FichaPersonagem CriarPersonagem(string nome); // produto 1
    List<IAcaoCombate> CriarAcoes();              // produto 2
}
```

Cada factory concreta garante que o personagem e suas ações sejam sempre compatíveis entre si. O `Narrador` não instancia `new Guerreiro()` ou `new Mago()` diretamente — ele usa a factory, recebendo a família completa já configurada.

### Estrutura no projeto
```
Interfaces/
  IPersonagemFactory.cs
Models/Factories/
  GuerreiroFactory.cs
  MagoFactory.cs
  OrcFactory.cs
```

---

## Como os dois padrões se complementam

A **Abstract Factory** monta o personagem já com suas **Strategies** configuradas. O `Combate` recebe o personagem pronto e usa suas ações sem precisar conhecer os tipos concretos — nem de quem é o personagem, nem de quais são suas ações.