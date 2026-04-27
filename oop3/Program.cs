using System;

class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < -273.15)
                throw new ArgumentOutOfRangeException(nameof(Celsius), "Temperature cannot be below absolute zero (-273.15°C).");

            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get => _celsius * 9 / 5 + 32;
        set
        {
            // Convert to Celsius and reuse validation
            Celsius = (value - 32) * 5 / 9;
        }
    }

    public Temperature(double celsius)
    {
        Celsius = celsius; // use property to enforce validation
    }

    public void Print()
    {
        Console.WriteLine($"{Celsius}°C / {Fahrenheit}°F");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Temperature t = new Temperature(25);
            t.Print();

            t.Fahrenheit = 100;
            t.Print();

            t.Celsius = -300; // should throw
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}