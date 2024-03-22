


using ConsoleApp3.Containers;
using ConsoleApp3.Exceptions;
using ConsoleApp3.Interfaces;

namespace DefaultNamespace;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool Hazardous;
    private int serialNumberCounter = 1;
    public LiquidContainer(int cargoMass, int height, int ownWeight, int depth, string serialNumber, double maxCargoLoad, bool hazardous) : base(cargoMass, height, ownWeight, depth, maxCargoLoad)
    {
        this.Hazardous = hazardous;
        this.SerialNumber = "KON-L-" + serialNumberCounter++;
    }

    public override void Load(int amount)
    {
        if (Hazardous == true)
        {
            MaxCargoLoad = MaxCargoLoad / 2;
        }
        else
        {
            MaxCargoLoad = MaxCargoLoad * 0.9;
        }
        
        if (CargoMass + amount + OwnWeight <= MaxCargoLoad)
        {
            CargoMass = CargoMass + amount;
        }
        else
        {
            Notify();
            throw new OverfillException("Cannot load");
        }
    }
    
    public override void Empty()
    {
        CargoMass = 0;
    }
    
    public void Notify()
    {
        throw new OverfillException("Hazardous situation in container " + SerialNumber);
    }
    public override string ToString()
    {
        return "Container number: " + SerialNumber + "\nCargo mass " + CargoMass
               + "\nHazardous: " + Hazardous + "\nDepth " + Depth
               + "\nOwn weight: " + OwnWeight + "\nMax cargo load: " + MaxCargoLoad
               + "\nHeight: " + Height;
    }

    public void notify()
    {
        throw new NotImplementedException();
    }
}
