using ConsoleApp2.Exceptions;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2;

public class KontenerChlodniczy : Kontener, IHazardNotifier
{
    
    protected string rodzajProduktu { get; set; }
    protected double temperatura { get; set; }
    protected string przypisaneDoKontenera { get; set; } 
    protected double wymaganaTemperaturadlaProduktu { get; set; } //Rodzaj produktu

    public KontenerChlodniczy(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string rodzajProduktu, double temperatura) : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = new NumerSeryjny("KON","C");
        this.rodzajProduktu = rodzajProduktu;
        this.temperatura = temperatura;
        przypisaneDoKontenera = rodzajProduktu;
        sprawdz();
    }

    public void sprawdz()
    {
        wymaganaTemperaturadlaProduktu = returnTemperature(rodzajProduktu);
        if (temperatura < wymaganaTemperaturadlaProduktu)
        {
            throw new TemperatureException("Zbyt niska temperatura w kontenerze.");
        }
    }

    public override void Unload()
    {
        masaLadunku = 0;
    }

    public override void Load(double waga, string produkt)
    {
        if (waga < maksymalnaLadownosc)
        {
            if (produkt == przypisaneDoKontenera)
            {
                masaLadunku = waga;
            }
            else
            {
                Console.WriteLine($"Nie mozna zaladowac {produkt} rodzaj tego kontenera to: {przypisaneDoKontenera}");
            }
        }
        else
        {
            Console.WriteLine("Przekroczono ladownosc");
        }
    }


    public double returnTemperature(string name)
    {
        double wartosc = 0;
        Dictionary<string, double> lista = new Dictionary<string, double>();
        lista.Add("Bananas", 13.3);
        lista.Add("Chocolate", 18);
        lista.Add("Fish", 2);
        lista.Add("Meat", -15);
        lista.Add("Ice cream", -18);
        lista.Add("Frozen pizza", -30);
        lista.Add("Cheese", 7.2);
        lista.Add("Sausages", 5);
        lista.Add("Butter", 20.5);
        lista.Add("Eggs", 19);

        foreach (var element in lista)
        {
            if (name == element.Key)
            {
                wartosc = element.Value;
            }
        }

        return wartosc;
    }

    public void warning(string msg)
    {
        Console.WriteLine(msg);
    }

    public override string ToString()
    {
        return $"Kontener chlodniczy: Masa ładunku: {masaLadunku}, Wysokość: {wysokosc}, Waga własna: {wagaWlasna}, Głębokość: {glebokosc}, Numer seryjny: {numerSeryjny}, Maksymalna ładowność: {maksymalnaLadownosc}, Rodzaj Produktu w Kontenerze: {rodzajProduktu}, Temperatura: {temperatura}";
    }
}