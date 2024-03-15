namespace ConsoleApp3.Containers;

public class LiquidContainer : Container
{
    protected LiquidContainer(int cargoWeight) : base(cargoWeight)
    {
        
    }

    public override void Load(int cargoWeight)
    {
        Console.WriteLine();
        base.Load(cargoWeight);
    }
}