using System;

public class KontoBankowe
{
    public string Wlasciciel { get; private set; }
    public decimal Stan { get; private set; }

    public KontoBankowe(string wlasciciel)
    {
        Wlasciciel = wlasciciel;
        Stan = 0; 
    }

    public void Wplac(decimal kwota)
    {
        if (kwota <= 0)
        {
            Console.WriteLine("Kwota musi byc wieksza od zera");
            return;
        }
        Stan += kwota;
        Console.WriteLine($"Wplacono: {kwota:C}. Nowy stan: {Stan:C}.");
    }

    public void Wyplac(decimal kwota)
    {
        if (kwota <= 0)
        {
            Console.WriteLine("Kwota musi byc wieksza od zera");
            return;
        }
        if (kwota > Stan)
        {
            Console.WriteLine("Niewystarczajace srodki na koncie");
            return;
        }
        Stan -= kwota;
        Console.WriteLine($"Wyplacono: {kwota:C}. Nowy stan: {Stan:C}.");
    }

    public void SprawdzStan()
    {
        Console.WriteLine($"Aktualny stan konta {Wlasciciel}: {Stan:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        KontoBankowe konto = new KontoBankowe("Maria Osypenko");
        bool dalej = true;

        while (dalej)
        {
            Console.WriteLine("\nWybierz operację:");
            Console.WriteLine("1. Wplata");
            Console.WriteLine("2. Wyplata");
            Console.WriteLine("3. Sprawdz stan konta");
            Console.WriteLine("4. Zakoncz");

            string wybor = Console.ReadLine(); //wczytywanie danych

            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj kwote do wplaty: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal kwotaWplaty))
                    {
                        konto.Wplac(kwotaWplaty);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowa kwota");
                    }
                    break;

                case "2":
                    Console.Write("Podaj kwote do wyplaty: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal kwotaWyplaty))
                    {
                        konto.Wyplac(kwotaWyplaty);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowa kwota");
                    }
                    break;

                case "3":
                    konto.SprawdzStan();
                    break;

                case "4":
                    dalej = false;
                    Console.WriteLine("no to koniec ");
                    break;

                default:
                    Console.WriteLine("Sprobuj ponownie!!!!!");
                    break;
            }
        }
    }
}