using ConsoleApp3.Interfaces;

namespace ConsoleApp3.Containers;

public class Container : IContainer
{
    
    

    public int CargoWeight { get;set;}
    public int CargoHeight { get;set;}
    public int CargWeightAlone { get;set;}
    public int CargoDeep { get;set;}
    public int CargoSerialNumber { get;set;}

    protected Container(int cargoWeight)
    {
        
    }
    public void Unload()
    {
        throw new NotImplementedException();
    }
    
    public virtual void Load(int cargoWeight)
    {
        throw new OverflowException();
    }
}