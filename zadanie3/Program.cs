using System;

namespace SystemBankowy
{
    public class KontoBankowe
    {
        String Wlasciciel { get; set; }
        decimal rn { get; set; }

        public KontoBankowe(string wlasciciel)
        {
            Wlasciciel = wlasciciel;
            rn = 0;
        }

        public void Wplacanie(decimal kwota)
        {
            if (kwota < 0)
            {
                Console.WriteLine("Kwota musi byc wieksza od zera");
                return;
            }

            rn += kwota;
            Console.WriteLine("Na konto wplacono" + kwota + " Nowy stan konta: " + rn);
        }

        public void Wyplacanie(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota musi byc wieksza od zera");
                return;
            }
            {
                Console.WriteLine("Niemoza wyplacic, jest za malo pieniedzy na koncie");
                return;
            }

            rn -= kwota;
            Console.WriteLine("Z konta wyplacono: " + kwota + " Nowy stan konta: " + rn);

        }
        public void Lokata()
        {
            decimal odsetki = rn * 0.05m;
            rn += odsetki;
            Console.WriteLine("Do konta z odsetek dodano: " + odsetki + " Stan konta po dodaniu: " + rn);
        }

        class Bank
        {
            static void Main(string[] args)
            {
                KontoBankowe konto = new KontoBankowe("Maria Osypenko");

                konto.Wyplacanie(5);
                konto.Wplacanie(10);
                konto.Wyplacanie(50);

                konto.Lokata();
                Console.WriteLine("Koncowy stan konta " + konto.Wlasciciel + " wynosi: " + konto.rn);

            }
        }
    }
}