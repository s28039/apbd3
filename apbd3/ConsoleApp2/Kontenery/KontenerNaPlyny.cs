using System.Security.Policy;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    private bool nieBezpieczny;
    
    public KontenerNaPlyny(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, bool nieBezpieczny) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = new NumerSeryjny("KON","L");
        this.nieBezpieczny = nieBezpieczny;
    }

    public void warning(string msg)
    {
        Console.WriteLine(numerSeryjny + ": " + msg);
    }
    
    
    public override string ToString()
    {
        return $"Kontener na plyny: Masa ładunku: {masaLadunku}, Wysokość: {wysokosc}, Waga własna: {wagaWlasna}, Głębokość: {glebokosc}, Numer seryjny: {numerSeryjny}, Maksymalna ładowność: {maksymalnaLadownosc}, Niebezpieczny: {nieBezpieczny}";
    }


    public override void Unload()
    {
        masaLadunku = 0;
    }

    public override void Load(double waga, string produkt)
    {
        if (nieBezpieczny == true)
        {
            if (waga > maksymalnaLadownosc / 2)
            {
                warning("Przekroczono limit! Kontener moze byc zaladowany do 50%");
            }
            else
            {
                masaLadunku = waga;
            }
        }
        else
        {
            if (waga > maksymalnaLadownosc * 0.9)
            {
                warning("Przekroczono limit! Kontener moze byc zaladowany do 90%");
            }
            else
            {
                masaLadunku = waga;
            }
        }



    }
    
}