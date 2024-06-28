using ConsoleApp2.Interfaces;

namespace ConsoleApp2;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public KontenerNaGaz(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = new NumerSeryjny("KON","G");
    }

    public override void Unload()
    {
        if (masaLadunku != 0)
        {
            masaLadunku = (masaLadunku * 0.05);
        }
        else
        {
            Console.WriteLine("Brak ladunku do rozladowania.");
        }
    }

    public void warning(string msg)
    {
        Console.WriteLine(numerSeryjny + ": " + msg);
    }

    public override void Load(double waga, string produkt)
    {
            masaLadunku = waga;
            checkWeight();
    }


    public override string ToString()
    {
        return $"Kontener na gaz: Masa ładunku: {masaLadunku}, Wysokość: {wysokosc}, Waga własna: {wagaWlasna}, Głębokość: {glebokosc}, Numer seryjny: {numerSeryjny}, Maksymalna ładowność: {maksymalnaLadownosc}";
    }
}