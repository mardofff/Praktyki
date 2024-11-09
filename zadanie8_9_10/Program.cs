using System;

public interface IPostac
{
    string Imie { get; set; }
    string Klasa { get; set; }
    int Sila { get; set; }
    int Zrecznosc { get; set; }
    int Inteligencja { get; set; }
    int HP { get; set; }
    int Mana { get; set; }
    int Szczescie { get; set; }

    void Wyswietlenie();
    void Atak(ISkill skill, Postac target);
}

public interface ISkill
{
    void Uzyj(Postac target);
}

public class Postac : IPostac
{
    public string Imie { get; set; }
    public string Klasa { get; set; }
    public int Sila { get; set; }
    public int Zrecznosc { get; set; }
    public int Inteligencja { get; set; }
    public int HP { get; set; }
    public int Mana { get; set; }
    public int Szczescie { get; set; }

    public Postac(string imie, string klasa, int sila, int zrecznosc, int inteligencja, int hp, int mana, int szczescie)
    {
        Imie = imie;
        Klasa = klasa;
        Sila = sila;
        Zrecznosc = zrecznosc;
        Inteligencja = inteligencja;
        HP = hp;
        Mana = mana;
        Szczescie = szczescie;
    }

    public void Wyswietlenie()
    {
        Console.WriteLine($"Imie: {Imie}");
        Console.WriteLine($"Klasa: {Klasa}");
        Console.WriteLine($"Sila: {Sila}");
        Console.WriteLine($"Zrecznosc: {Zrecznosc}");
        Console.WriteLine($"Inteligencja: {Inteligencja}");
        Console.WriteLine($"HP: {HP}");
        Console.WriteLine($"Mana: {Mana}");
        Console.WriteLine($"Szczescie: {Szczescie}");
    }

    public void Atak(ISkill skill, Postac target)
    {
        skill.Uzyj(target);
    }
}

public class Enemy : Postac
{
    public Enemy(string imie, string klasa, int sila, int zrecznosc, int inteligencja, int hp, int mana, int szczescie)
        : base(imie, klasa, sila, zrecznosc, inteligencja, hp, mana, szczescie)
    {
    }
}

public class AttackSkill : ISkill
{
    public void Uzyj(Postac target)
    {
        target.HP -= 10;
        Console.WriteLine($"{target.Imie} zostal zaatakowany, -10HP!");
    }
}

class Dzialanie
{
    static void Main(string[] args)
    {
        Postac postac1 = new Postac("Nogger", "Wojownik", 6, 1, 2, 50, 20, 1);
        Postac enemy1 = new Enemy("Bilicki", "true enemy", 666, 6, 6, 100, 16, 6);

        Console.WriteLine("-Postac-");
        postac1.Wyswietlenie();
        Console.WriteLine();

        Console.WriteLine("-Enemy-");
        enemy1.Wyswietlenie();
        Console.WriteLine();

        ISkill attack = new AttackSkill();

        Console.WriteLine("Postac atakuje enemy:");
        postac1.Atak(attack, enemy1);
        Console.WriteLine($"HP enemy po ataku: {enemy1.HP}\n");

        Console.WriteLine("Enemy atakuje postac:");
        enemy1.Atak(attack, postac1);
        Console.WriteLine($"HP postaci po ataku: {postac1.HP}\n");
    }
}
