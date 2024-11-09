using System;

namespace Zadanie1

{
    public interface IFigury
    {
        double ObliczObwod();
        double ObliczPole();
    }

    public abstract class Figury : IFigury
    //klasa abstrakcyjna
    {
        public abstract double ObliczPole(); //metoda
        public abstract double ObliczObwod();
    }

    public class Trapez : Figury //klasa trapez dziedziczy po innej klasie o nazwie figury
    {
        double a, b, h, c, d;

        public Trapez(double a, double b, double h, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = c;
            this.d = d;
        }
        public override double ObliczPole() => (a + b) * h / 2;
        public override double ObliczObwod() => a + b + h + c + d;

    }

    public class Romb : Figury
    {
        double a, h;

        public Romb(double a, double h)
        {
            this.a = a;
            this.h = h;
        }
        public override double ObliczPole() => a * h;
        public override double ObliczObwod() => 4 * a;

    }
    public class Prostokat : Figury
    {
        double a, b;

        public Prostokat(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double ObliczPole() => a * b;
        public override double ObliczObwod() => 2 * (a + b);

    }
    class Dzialanie
    {
        static void Main()
        {
            Trapez trapez = new Trapez(5, 6, 4, 3, 5);
            Romb romb = new Romb(4, 5);
            Prostokat prostokat = new Prostokat(5, 8);

            Console.WriteLine("Trapez. Pole:" + trapez.ObliczPole() + " Obwod: " + trapez.ObliczObwod());
            Console.WriteLine("Romb. Pole: " + romb.ObliczPole() + " Obwod: " + romb.ObliczObwod());
            Console.WriteLine("Prostokat. Pole: " + prostokat.ObliczPole() + " Obwod: " + prostokat.ObliczObwod());
        }
    }

}