using ConsoleApp3.Interfaces;



using ConsoleApp3;
using ConsoleApp3.Containers;

namespace DefaultNamespace;

public class CoolingContainer : Container, IHazardNotifier
{
    public double temperature;
    public string productType;
    private int serialNumberCounter = 1;
    public CoolingContainer(double temperature, string productType, int cargoMass, int height, int ownWeight, int depth, string serialNumber, double maxCargoLoad) : base(cargoMass, height, ownWeight, depth, maxCargoLoad)
    {
        this.temperature = temperature;
        this.productType = productType;
        this.SerialNumber = "KON-C-" + serialNumberCounter++;
    }

    public void load(int amount, int productTemperature, string productType)
    {
        if (temperature >= productTemperature)
        {
            if (productType.Equals(this.productType))
            {
                base.load(amount);     
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

    public override void empty()
    {
        double mass = CargoMass;
        base.empty();
    }

    public void notify()
    {
        throw new OverfillException("Container overloaded: " + SerialNumber);
    }
}
