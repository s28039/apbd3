using ConsoleApp3.Exceptions;
using ConsoleApp3.Interfaces;
using DefaultNamespace;

namespace ConsoleApp3.Containers;

using ConsoleApp3;



public class GasContainer : Container, IHazardNotifier
{
    private static int serialNumberCounter = 1;
    public GasContainer(int cargoMass, int height, int ownWeight, int depth, double maxCargoLoad) : base(cargoMass, height, ownWeight, depth, maxCargoLoad)
    {
        this.SerialNumber = "Container Gas" + serialNumberCounter++;
    }

    public override void Load(int amount)
    {
        if (CargoMass + OwnWeight + amount <= MaxCargoLoad)
        {
            CargoMass = CargoMass + amount;
        }
        else
        {
            Notify();
        }
    }

    public override void Empty()
    {
        double mass = CargoMass;
        base.Empty();
        base.Load((int)(mass * 0.5));
    }

    public void Notify()
    {
        throw new OverfillException("Overfull container: " + SerialNumber);
    }

    public void notify()
    {
        throw new NotImplementedException();
    }
}
