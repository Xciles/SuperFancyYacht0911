using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesome.Inherit
{
    // Ik ben auto dealer en ik wil mijn autos beheren
    public interface ICar
    {
        string Model { get; set; }
        int NumberOfWheels { get; set; }
        float AmountOfFuel { get; set; }

        void DriveAround(string message);
    }

    public abstract class Car : ICar
    {
        public virtual int NumberOfWheels { get; set; } = 4;
        public int NumberOfDoors { get; set; } = 4;
        public string Model { get; set; }
        public string Description { get; set; }
        public float AmountOfFuel { get; set; }

        public virtual void DriveAround(string message)
        {
            Console.WriteLine($"Driving around {message}");
        }

        //public abstract void OpenDoor();
    }

    public class Audi : Car
    {
        public override void DriveAround(string message)
        {
            Console.WriteLine($"Driving around in my Audi {message}");
        }
    }

    public class Volkwagen : Car
    {

    }

    public class HansAuto : Car
    {
        public override int NumberOfWheels { get; set; } = 5;

    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ICar carInterface = new Audi();

            var listOfCars = new List<ICar>();

            listOfCars.Add(new Volkwagen());
            listOfCars.Add(new Audi());

            var list = new List<ICar>();
            foreach (var item in listOfCars)
            {
                if (item.AmountOfFuel > 50)
                {
                    list.Add(item);
                }
            }
            // iets doen met het lijstje

            var listOfVolkswagen = listOfCars.OfType<Volkwagen>();
            Func<ICar, bool> func = Method;
            var allVog2 = listOfCars.Where(Method);

            var allVog3 = listOfCars.Where(car => car.AmountOfFuel > 50);

            var result = listOfCars.Where(car => car.AmountOfFuel > 50).Select(x => new { x.Model, x.AmountOfFuel });
            
            // Inherriatance
            // interfaces
            // new 
            // Lijstje

            // Library
            // Backgrounding


            Task.Run(() =>
            {
                // thing in the background
            });
        }

        public static bool Method(ICar car)
        {
            return car.AmountOfFuel > 50;
        }
    }
}
