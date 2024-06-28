using System.Text.RegularExpressions;
using ConsoleApp2.Exceptions;

namespace ConsoleApp2;

public abstract class Kontener
{
    protected Kontener(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
    {
        this.masaLadunku = masaLadunku;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        numerSeryjny = null;
        this.maksymalnaLadownosc = maksymalnaLadownosc;
        checkWeight();
    }

    public double masaLadunku { get; set; }
    protected double wysokosc { get; set; }
    protected double wagaWlasna { get; set; }
    protected double glebokosc { get; set; }
    public NumerSeryjny numerSeryjny { get; set; }
    protected double maksymalnaLadownosc { get; set; }


    public abstract void Unload();

    public abstract void Load(double waga, string produkt);

    public virtual void checkWeight()
    {
        if (masaLadunku > maksymalnaLadownosc)
        {
            throw new OverfillException("To much weight!");
        }
    }
    
    public virtual string ToString()
    {
        return $"Kontener: Masa ładunku: {masaLadunku}, Wysokość: {wysokosc}, Waga własna: {wagaWlasna}, Głębokość: {glebokosc}, Numer seryjny: {numerSeryjny}, Maksymalna ładowność: {maksymalnaLadownosc}";
    }


}