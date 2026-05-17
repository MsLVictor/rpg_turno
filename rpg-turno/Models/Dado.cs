namespace rpg_turno.Models;

public static class Dado
{
    private static readonly Random _rng = new();

    public static int RolarD20() => _rng.Next(1, 21);
}
