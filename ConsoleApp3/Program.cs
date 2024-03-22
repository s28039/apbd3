using System;
using ConsoleApp3;
using ConsoleApp3.Containers;
using DefaultNamespace;

LiquidContainer liquidOne = new LiquidContainer(10, 10, 1000, 10, "Serial1234", 1000000, false);
liquidOne.Load(2137);

Console.WriteLine(liquidOne.ToString());

GasContainer gasOne = new GasContainer(100, 1000, 10000, 100, 10000);

Ship ship = new Ship(5, 10, 10000);

ship.Load(gasOne);
ship.Load(liquidOne);
ship.Load(gasOne);

ship.ListContainers();

Console.WriteLine();
ship.RemoveContainerFromShip(gasOne);
ship.ListContainers();

gasOne.Load(2137);
Console.WriteLine("---------------------------");
Console.WriteLine(gasOne.ToString());
Console.WriteLine("---------------------------");
gasOne.Empty();
Console.WriteLine("---------------------------");
Console.WriteLine(gasOne.ToString());
Console.WriteLine("---------------------------");

RefrigeratedContainer coolingContainer = new RefrigeratedContainer(2, "Fries", 1000, 1000, 10000, 10000, "Container ref", 4000);

Console.WriteLine(coolingContainer.ToString());
Console.WriteLine();




