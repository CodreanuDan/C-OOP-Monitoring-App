
using System;
using CommonReferences;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Instantierea clasei SensorValue\n\r");

        PumpSensorValues sensorValuesPump = new PumpSensorValues(3);
        sensorValuesPump.StartPumping();

        Console.ReadLine();
        sensorValuesPump.StopPumping();
    }

    internal static void DisplaySensorValues(string headerText, SensorValue sensor)
    {
        Console.WriteLine("\t" + headerText);
        Console.WriteLine("\t\t Type = {0} ", sensor.Type.ToString());
        Console.WriteLine("\t\t TimeStamp = {0} ", sensor.TimeStampString);
        Console.WriteLine("\t\t Value = {0} ", sensor.Value.ToString("0.00"));
    }
}
