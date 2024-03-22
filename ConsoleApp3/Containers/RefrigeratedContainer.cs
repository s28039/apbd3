using ConsoleApp3.Exceptions;
using ConsoleApp3.Interfaces;
using DefaultNamespace;

namespace ConsoleApp3.Containers;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public double temperature;
    public string productType;
    private int serialNumberCounter = 1;
    public RefrigeratedContainer(double temperature, string productType, int cargoMass, int height, int ownWeight, int depth, string serialNumber, double maxCargoLoad) : base(cargoMass, height, ownWeight, depth, maxCargoLoad)
    {
        this.temperature = temperature;
        this.productType = productType;
        this.SerialNumber = "Container Refrigerated: " + serialNumberCounter++;
    }

    public void Load(int amount, int productTemperature, string productType)
    {
        if (temperature >= productTemperature)
        {
            if (productType.Equals(this.productType))
            {
                base.Load(amount);     
            }
            else
            {
                Console.WriteLine("Different container types");
            }
        }
        else
        {
            Console.WriteLine("Container temperature too low");
        }
    }

    public override void Empty()
    {
        double mass = CargoMass;
        base.Empty();
    }

    public void notify()
    {
        throw new OverfillException("Container overloaded: " + SerialNumber);
    }
}
