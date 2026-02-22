using rpg_turno.Models;

var heroi = new Guerreiro("Presunto");
var miniOrc = new Orc("Ugluk");

var arena = new Combate();

arena.IniciarDuelo(heroi, miniOrc);
