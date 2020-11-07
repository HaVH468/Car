using System;

namespace ObjectOrientedProgrammingBasics
{
    public class Car
    {
        private string _make;
        private int _yearOfProduction;
        private string _color;
        private int _petroTankCapacity;
        private int _petroUsagePer100km;
        private double _kilometerCounter;
        private double _petrolLevel;

        public string Make => _make;
        public int YearOfProduction => _yearOfProduction;
        public string Color => _color;
        public int PetroTankCapacity => _petroTankCapacity;
        public int PetroUsagePer100km => _petroUsagePer100km;
        public int KilometerCounter => Convert.ToInt32(_kilometerCounter);
        public double PetroLevel => _petrolLevel;

        public Car(string make, int yearOfProduction, string color, int petroTankCapacity, int petroUsagePer100km)
        {
            if (string.IsNullOrEmpty(make))
                throw new ArgumentNullException("Make cannot be empty");
            if (string.IsNullOrEmpty(color))
                throw new ArgumentNullException("Colour cannot be empty");
            if (yearOfProduction < 2000 || yearOfProduction > DateTime.Now.Year)
                throw new ArithmeticException("Year of the production can be a number from 2000 to current year");
            if (petroTankCapacity < 1)
                throw new ArgumentException("Petro tank capacity needs to be positive");
            if (petroUsagePer100km < 0)
                throw new ArgumentException("Petro usage needs to be not negative");

            _make = make;
            _color = color;
            _yearOfProduction = yearOfProduction;
            _petroTankCapacity = petroTankCapacity;
            _petroUsagePer100km = petroUsagePer100km;
        }

        public void Tank(int liters)
        {
            if (liters < 0)
                throw new ArgumentException("Provide a positive value");

            if (_petrolLevel + liters > _petroTankCapacity)
                _petrolLevel = _petroTankCapacity;

            else
                _petrolLevel += liters;
        }

        public void Drive(int kilometers)
        {
            var range = _petrolLevel * 100 / _petroUsagePer100km;
            if (kilometers > range)
            {
                _kilometerCounter += range;
                _petrolLevel = 0;
            }
            else
            {
                _kilometerCounter += kilometers;
                _petrolLevel -= kilometers * PetroUsagePer100km / 100;
            }
        }

        public void ChangeColor(string newColor)
        {
            _color = newColor;
        }

        public void DailyKilometersCounter (double kilometers)
        {
            var maximumKilometers = 10000;

            if (_kilometerCounter > maximumKilometers)
                _kilometerCounter = 0;
            else
                _kilometerCounter += kilometers;
        }


    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Ford", 2019, "Red", 60, 6);
            Console.WriteLine(car1.KilometerCounter);
            car1.Tank(30);
            car1.Drive(250);
            car1.ChangeColor("Black");
            car1.DailyKilometersCounter(5000);
            Console.WriteLine(car1.KilometerCounter);

            
            
        }

    }
}
