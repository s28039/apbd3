using ConsoleApp3.Containers;
using ConsoleApp3.Exceptions;

namespace ConsoleApp3;

using DefaultNamespace;


public class Ship
{
    public int maxNumber;
    public double maxSpeed;
    public double maxWeight;
    public List<Container> containerList;
    private double loadedMass;

    public Ship(int maxNumber, double maxSpeed, double maxWeight)
    {
        this.maxNumber = maxNumber;
        this.maxSpeed = maxSpeed;
        this.maxWeight = maxWeight;
        containerList = new List<Container>();
        loadedMass = 0;
    }

    public void Load(Container container)
    {
        if (loadedMass + container.CargoMass < maxWeight)
        {
            containerList.Add(container);
            loadedMass = loadedMass + container.CargoMass;
        }
        else
        {
            throw new OverfillException("Ship full");
        }
    }


    public void RemoveContainerFromShip(Container container)
    {
        containerList.Remove(container);
    }



    public void ListContainers()
    {
        foreach (Container container in containerList)
        {
            Console.WriteLine(container.GetType());
        }
    }
}
