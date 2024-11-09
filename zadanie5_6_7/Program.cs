using System;
using System.Collections.Generic;
using System.Linq;

public class Produkty
{
    public int ID { get; set; }
    public string Nazwa { get; set; }
    public decimal Cena { get; set; }
    public string Kategoria { get; set; } 

    public Produkty(int id, string nazwa, decimal cena, string kategoria)
    {
        ID = id;
        Nazwa = nazwa;
        Cena = cena;
        Kategoria = kategoria;
    }
}

    public class Koszyk
    {
    private List<Produkty> produkty = new List<Produkty>();
    public void DodajProdukt(Produkty produkt)
    {
        produkty.Add(produkt);
    }

    public void Srodek()
    {
        if (produkty.Count == 0)
        {
            Console.WriteLine("Koszyk jest pusty");
            return;
        }

        Console.WriteLine("Produkty ktore sa koszyku:");
        foreach (var produkt in produkty)
        {
            Console.WriteLine($"ID: {produkt.ID}, Nazwa: {produkt.Nazwa}, Cena: {produkt.Cena:C}, Kategoria: {produkt.Kategoria}");
        }
    }
    public void Sortuj()
    {
        produkty = produkty.OrderByDescending(p => p.Cena).ToList();
    }
    public List<Produkty> Filtruj(string kategoria)
    {
        return produkty.Where(p => p.Kategoria.Equals(kategoria, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
class Dzialanie
{
    static void Main(string[] args)
    {
        List<Produkty> bazaDanychProduktow = new List<Produkty>
        {
            new Produkty(1, "Ser", 2.60m, "Nabiał"),
            new Produkty(2, "Mleko", 3.40m, "Nabiał"),
            new Produkty(3, "Lipton", 9.20m, "Napoje"),
            new Produkty(4, "Chleb", 2.00m, "Pieczywo"),
            new Produkty(5, "Masło", 4.50m, "Nabiał"),
            new Produkty(6, "Woda", 1.50m, "Napoje"),
            new Produkty(7, "Jogurt", 3.20m, "Nabiał"),
        };

        Koszyk koszyk = new Koszyk();
 
        foreach (var produkt in bazaDanychProduktow)
        {
            koszyk.DodajProdukt(produkt);
        }

        koszyk.Sortuj();
        Console.WriteLine("\nZawartość koszyka po sortowaniu (od najdroższego do najtańszego):");
        koszyk.Srodek();

        string wybranaKategoria = "Nabiał";
        var produktyZNabialu = koszyk.Filtruj(wybranaKategoria);

        Console.WriteLine($"\nProdukty w koszyku z kategorii '{wybranaKategoria}':");
        foreach (var produkt in produktyZNabialu)
        {
            Console.WriteLine($"ID: {produkt.ID}, Nazwa: {produkt.Nazwa}, Cena: {produkt.Cena:C}, Kategoria: {produkt.Kategoria}");
        }
    }
}
