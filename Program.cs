using System;
using System.Collections.Generic;
using System.Linq;
using AssignmentDay1;


class Car
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public CarType Type { get; set; }
}

class CarManager
{
    private List<Car> cars = new List<Car>();

    public void AddCar()
    {
        try
        {
            Console.Write("Enter car type (Fuel/Electric): ");
            if (!Enum.TryParse(Console.ReadLine()?.Trim(), true, out CarType type))
            {
                Console.WriteLine("Invalid type.");
                return;
            }

            Console.Write("Enter Make: ");
            string make = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter Model: ");
            string model = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter Year: ");
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int year))
            {
                Console.WriteLine("Invalid year.");
                return;
            }

            cars.Add(new Car { Make = make, Model = model, Year = year, Type = type });
            Console.WriteLine("Car added success!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error: {ex.Message}");
        }
    }

    public void ShowAllCars()
    {
        try 
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("Car not found.");
                return;
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Make} {car.Model}, {car.Year}, {car.Type}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void FindCarByMake()
    {
        try
        {
            Console.Write("Enter Make to search: ");
            string make = Console.ReadLine()?.Trim() ?? "";
            var results = cars.Where(car => car.Make.ToLower() == make.ToLower()).ToList();
            InfoCars(results);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void FilterCarsByType()
    {
        try
        {
            Console.Write("Enter Type (Fuel/Electric): ");
            if (!Enum.TryParse(Console.ReadLine(), true, out CarType type))
            {
                Console.WriteLine("Invalid type.");
                return;
            }
            var results = cars.Where(car => car.Type == type).ToList();
            InfoCars(results);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void DeleteCarByModel()
    {
        try
        {
            Console.Write("Enter Model to remove: ");
            string model = Console.ReadLine()?.Trim() ?? "";
            var carToRemove = cars.FirstOrDefault(car => car.Model.ToLower() == model.ToLower());
            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                Console.WriteLine("Car removed success.");
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void InfoCars(List<Car> carList)
    {
        if (carList.Count == 0)
        {
            Console.WriteLine("Car not found.");
            return;
        }
        foreach (var car in carList)
        {
            Console.WriteLine($"{car.Make} {car.Model}, {car.Year}, {car.Type}");
        }
    }
}

class Program
{
    static void Main()
    {
        CarManager manager = new CarManager();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a Car");
            Console.WriteLine("2. View All Cars");
            Console.WriteLine("3. Search Car by Make");
            Console.WriteLine("4. Filter Cars by Type");
            Console.WriteLine("5. Remove a Car by Model");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

            switch (choice)
            {
                case 1:
                    manager.AddCar();
                    break;
                case 2:
                    manager.ShowAllCars();
                    break;
                case 3:
                    manager.FindCarByMake();
                    break;
                case 4:
                    manager.FilterCarsByType();
                    break;
                case 5:
                    manager.DeleteCarByModel();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Again: ");
                    break;
            }
        }
    }
}
