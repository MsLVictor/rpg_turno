using rpg_turno.Models;

// Narrador.Introducao();
// Narrador.CriandoPersonagem();

var heroi = new Mago("Presunto");
var miniOrc = new Orc("Ugluk");

var arena = new Combate();

arena.IniciarDuelo(heroi, miniOrc);
