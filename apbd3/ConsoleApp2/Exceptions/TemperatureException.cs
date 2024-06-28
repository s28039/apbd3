namespace ConsoleApp2.Exceptions;

public class TemperatureException : Exception
{
    public TemperatureException() { }
    public TemperatureException(string message) : base(message) { }
}