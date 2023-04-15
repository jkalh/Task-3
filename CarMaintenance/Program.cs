using System;

namespace CarMaintenance
{
    class Wheel
    {
        public string Brand { get; set; }
        public int Size { get; set; }
    }

    class Engine
    {
        public string Type { get; set; }
        public int Horsepower { get; set; }
    }

    class Car
    {
        private Wheel[] wheels;
        private Engine engine;
        private double fuelCapacity;
        private double fuelLevel;
        private string brand;

        public Car(Wheel[] wheels, Engine engine, double fuelCapacity, string brand)
        {
           
            this.engine = engine;
            this.fuelCapacity = fuelCapacity;
            this.fuelLevel = fuelCapacity;
            this.brand = brand;
            this.wheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
            {
                wheels[i] = new Wheel();
            }
        }

        public void Drive(double distance, double speed) 
        {
            double fuelSpent = distance / (10 * speed);
            if (fuelSpent > fuelLevel)
            {
                Console.WriteLine("Error: Not enough fuel to drive that distance.");
                return;
            }
            fuelLevel -= fuelSpent;
            Console.WriteLine("Driving {0} miles at {1} mph.", distance, speed);
        }
        //метод добавляет указанное количество топлива к текущему уровню топлива в автомобиле с помощью оператора +,
        //но он также ограничивает уровень топлива максимальным запасом топлива в автомобиле (сохраненным в fuelCapacity),
        //используя 'Math.min
        public void Refuel(double amount) // заправляться
        {
            fuelLevel = Math.Min(fuelLevel + amount, fuelCapacity);
            Console.WriteLine("Refueled {0} gallons.", amount);
        }

        public void ChangeWheel(int wheelIndex, Wheel newWheel)
        {
            wheels[wheelIndex] = newWheel;
            Console.WriteLine("Changed wheel {0} to {1}.", wheelIndex, newWheel.Brand);
        }

        public void DisplayBrand()
        {
            Console.WriteLine("This car is a {0}.", brand);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Wheel[] wheels = new Wheel[] {
            new Wheel { Brand = "Michelin", Size = 18 },
            new Wheel { Brand = "Michelin", Size = 18 },
            new Wheel { Brand = "Michelin", Size = 18 },
            new Wheel { Brand = "Michelin", Size = 18 }
            };

            Engine engine = new Engine { Type = "V8", Horsepower = 500 };

            Car car = new Car(wheels, engine, 20, "Ford Mustang");
            car.DisplayBrand();  // This car is a Ford Mustang.

            car.ChangeWheel(2, new Wheel { Brand = "Pirelli", Size = 18 });  // Changed wheel 2 to Pirelli.

            car.Refuel(10);  // Refueled 10 gallons.

            car.Drive(100, 60);  // Driving 100 miles at 60 mph.
            Console.ReadLine();
        }
    }
}
