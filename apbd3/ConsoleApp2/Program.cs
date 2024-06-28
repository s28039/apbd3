
using ConsoleApp2;

List<Statek> statki = new List<Statek>();
List<Kontener> konteners = new List<Kontener>();


while (true)
{
    showShips();
    Console.WriteLine("Wybierz numer:");
    Console.WriteLine("1. Dodaj kontenerowiec.");
    Console.WriteLine("2. Usun Kontenerowiec");
    Console.WriteLine("3. Przejdz do danego kontenerowca");
    Console.WriteLine("4. Przejdz listy kontenerow");
    string wybor = Console.ReadLine();
    int w = int.Parse(wybor);
    switch (w)
    {
        case 1:
            Console.WriteLine("Wpisz predkosc statku: ");
            double predkosc = Double.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz maksymalna liczbe kontenerow: ");
            int maksymalnaLiczbaKontenerow = int.Parse(Console.ReadLine());
            Console.WriteLine("Wpisz maksymalna wage statku: ");
            double maksymalnaWaga = Double.Parse(Console.ReadLine());
            
            statki.Add(new Statek(predkosc,maksymalnaLiczbaKontenerow,maksymalnaWaga));
            
            break;
        case 2:
            Console.WriteLine("Wybierz numer statku do usuniecia: ");
            int doUsuniecia = int.Parse(Console.ReadLine());
            for (int i = statki.Count - 1; i >= 0; i--)
            {
                if (statki[i].numerStatku.Equals(doUsuniecia))
                {
                    statki.RemoveAt(i);
                }
            }
            break;
        case 3:
            Statek m = null;
            Console.WriteLine("Wpisz numer statku: ");
            int doWyswietlenia = int.Parse(Console.ReadLine());
            for (int i = statki.Count - 1; i >= 0; i--)
            {
                if (statki[i].numerStatku.Equals(doWyswietlenia))
                {
                    m = statki[i];
                    m.pokazKontenery();
                }
            }
            break;
        case 4:
            pokazKontenery();
            Console.WriteLine("Wybor:");
            Console.WriteLine("1. Dodaj kontener");
            Console.WriteLine("2. Usun kontener");
            Console.WriteLine("3. KONIEC");
            int j = int.Parse(Console.ReadLine());
            switch (j)
            {
                case 1:
                    Console.WriteLine("1. Kontener na plyn");
                    Console.WriteLine("2. Kontener na gaz");
                    Console.WriteLine("3. Kontener chlodniczy");
                    int b = int.Parse(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                            konteners.Add(new KontenerNaPlyny(0,5,100,5,250,false));
                            break;
                        case 2:
                            konteners.Add(new KontenerNaGaz(0,5,100,5,250));
                            break;
                        case 3:
                            konteners.Add(new KontenerChlodniczy(0,5,100,5,250,"Bananas",15));
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Wpisz numer kontenera do usuniecia.");
                    string numerek = Console.ReadLine();
                    for (int i = konteners.Count - 1; i >= 0; i--)
                    {
                        if (konteners[i].numerSeryjny.ToString().Equals(numerek))
                        {
                            konteners.RemoveAt(i);
                        }
                    }
                    break;
            }
            
            break;
        default:
            Console.WriteLine("Nieprawidlowy wybor.");
            break;
    }





    
}







void showShips()
{
    foreach (Statek s in statki)
    {
        if (statki.Count != 0)
        {
            s.info();
        }
        else
        {
            Console.WriteLine("Brak");
        }
            
    }
}




void pokazKontenery()
{
    Console.WriteLine("===========Lista kontenerow=========");
    foreach (Kontener k in konteners)
    {
        Console.WriteLine(k.ToString());
    }
    Console.WriteLine("====================================");
}










