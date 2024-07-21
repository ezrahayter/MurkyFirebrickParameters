using System;

class Program
{
    static void Main(string[] args)
    {
        double[] temperatures = new double[5];

        Console.WriteLine("Enter five daily Fahrenheit temperatures (-30 to 130):");

        for (int i = 0; i < 5; i++)
        {
            double temperature = GetValidTemperature();

            temperatures[i] = temperature;
        }

        string trend = DetermineTemperatureTrend(temperatures);

        Console.WriteLine($"Temperature trend: {trend}");

        Console.WriteLine("Temperatures entered:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Day {i + 1}: {temperatures[i]}°F");
        }

        double averageTemperature = CalculateAverageTemperature(temperatures);

        Console.WriteLine($"Average temperature: {averageTemperature:F2}°F");
    }

    static double GetValidTemperature()
    {
        double temperature;
        do
        {
            Console.Write("Enter temperature: ");
            if (!double.TryParse(Console.ReadLine(), out temperature))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            else if (temperature < -30 || temperature > 130)
            {
                Console.WriteLine("Temperature must be between -30 and 130 degrees Fahrenheit.");
            }
        } while (temperature < -30 || temperature > 130);

        return temperature;
    }

    static string DetermineTemperatureTrend(double[] temperatures)
    {
        bool gettingWarmer = true;
        bool gettingCooler = true;

        for (int i = 1; i < 5; i++)
        {
            if (temperatures[i] <= temperatures[i - 1])
            {
                gettingWarmer = false;
            }
            if (temperatures[i] >= temperatures[i - 1])
            {
                gettingCooler = false;
            }
        }

        if (gettingWarmer)
        {
            return "Getting warmer";
        }
        else if (gettingCooler)
        {
            return "Getting cooler";
        }
        else
        {
            return "It's a mixed bag";
        }
    }
    static double CalculateAverageTemperature(double[] temperatures)
    {
        
        double sum = 0;
        foreach (double temperature in temperatures)
        {
            sum += temperature;
        }
        return sum / temperatures.Length;
    }
}