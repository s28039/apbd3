namespace ConsoleApp3.Containers;

public abstract class Container
{
    public int CargoMass { get; set; }
    public int Height { get; set; }
    public int OwnWeight { get; set; }
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxCargoLoad { get; set; }
    public bool Hazardous { get; set; }

    public Container(int cargoMass, int height, int ownWeight, int depth, double maxCargoLoad)
    {
        this.Hazardous = Hazardous;
        this.CargoMass = cargoMass;
        this.Height = height;
        this.OwnWeight = ownWeight;
        this.Depth = depth;
        this.MaxCargoLoad = maxCargoLoad;
    }

    public virtual void Empty()
    {
        CargoMass = 0;
    }

    public virtual void Load(int amount)
    {
        if (CargoMass + OwnWeight + amount <= MaxCargoLoad)
        {
            CargoMass = CargoMass + amount;
        }
        else
        {
            throw new Exception("OverfillException " + SerialNumber);
        }
    }
    public override string ToString()
    {
        return "Container number: " + SerialNumber + "\nCargo mass " + CargoMass
               + "\nHazardous: " + Hazardous + "\nDepth " + Depth
               + "\nOwn weight: " + OwnWeight + "\nMax cargo load: " + MaxCargoLoad
               + "\nHeight: " + Height;
    }
}
