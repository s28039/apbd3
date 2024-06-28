using ConsoleApp2.Exceptions;

namespace ConsoleApp2;

public class Statek
{
    protected List<Kontener> magazyn = new List<Kontener>();
    protected double predkosc; //w wezlach
    protected int maksymalnaLiczbaKontenerow; 
    protected double maksymalnaWaga; //w tonach
    protected double aktualnaMasa;
    protected int aktualnaLiczbaKontenerow;
    public static int numer = 1;
    public int numerStatku;

    public Statek(double predkosc, int maksymalnaLiczbaKontenerow, double maksymalnaWaga)
    {
        this.predkosc = predkosc;
        this.maksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
        this.maksymalnaWaga = maksymalnaWaga*1000;
        numerStatku = numer;
        numer++;
    }

    public void pokazKontenery()
    {
        Console.WriteLine("=======Kontenery na statku=======");
        foreach (Kontener k in magazyn)
        {
            Console.WriteLine(k.ToString());
        }
        Console.WriteLine("=================================");
    }

    public void add(Kontener k)
    {

        if (!magazyn.Contains(k))
        {
            if (k.masaLadunku + aktualnaMasa <= maksymalnaWaga && aktualnaLiczbaKontenerow+1 <= maksymalnaLiczbaKontenerow)
            {
                magazyn.Add(k);
                aktualnaLiczbaKontenerow++;
                aktualnaMasa += k.masaLadunku;
            }
            else
            {
                Console.WriteLine("Nie mozna dodac wiecej kontenerow, statek zaladowany calkowicie");
            }
        }
    }
    
    
    public void add(List<Kontener> list)
    {
        foreach (Kontener k in list)
        {
            if (!magazyn.Contains(k))
            {
                if (k.masaLadunku + aktualnaMasa <= maksymalnaWaga && aktualnaLiczbaKontenerow+1 <= maksymalnaLiczbaKontenerow)
                {
                    magazyn.Add(k);
                    aktualnaLiczbaKontenerow++;
                    aktualnaMasa += k.masaLadunku;
                }
                else
                {
                    Console.WriteLine("Nie mozna dodac wiecej kontenerow, statek zaladowany calkowicie");
                }
            }
        }
    }

    public void Unload()
    {
        magazyn.Clear();
    }

    public void exchange(string numer, Kontener k2)
    {
        foreach (Kontener k in magazyn)
        {
            if (Equals(k.numerSeryjny, numer))
            {
                magazyn.Remove(k);
                magazyn.Add(k2);
            }
        }
    }

    public void move(Kontener k, Statek s)
    {
        if (magazyn.Contains(k))
        {
            magazyn.Remove(k);
            s.add(k);
        }
    }


    public void remove(Kontener k)
    {
        magazyn.Remove(k);
        aktualnaLiczbaKontenerow--;
        aktualnaMasa -= k.masaLadunku;
    }

    public void Curinfo()
    {
        Console.WriteLine("=======Aktualne informacje=======");
        Console.WriteLine($"Liczba kontenerow na statku: {aktualnaLiczbaKontenerow}");
        Console.WriteLine($"Liczba masa kontenerow: {aktualnaMasa}");
        Console.WriteLine("=================================");
    }
    
    public void info()
    {
        Console.WriteLine("=========Lista statkow=========");
        Console.WriteLine($"Statek numer {numerStatku}");
        Console.WriteLine($"Maksymalna liczba kontenerow: {maksymalnaLiczbaKontenerow}");
        Console.WriteLine($"Dopuszczlna waga: {maksymalnaWaga}");
        Console.WriteLine($"Dopuszczlna predkosc: {predkosc}");
        Console.WriteLine("=================================");
    }

    
}