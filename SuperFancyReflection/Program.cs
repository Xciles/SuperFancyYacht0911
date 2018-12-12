using System;
using System.Linq;
using System.Reflection;

namespace SuperFancyReflection
{
    public abstract class Animal
    {
    }

    public class Dog : Animal
    {

    }

    public class Cat : Animal
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dog = new Dog();

            var listOfTypes = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(x => x.BaseType == typeof(Animal));

            var dog2 = Activator.CreateInstance<Dog>();
            var dog3 = Activator.CreateInstance(listOfTypes.First());


            Console.ReadKey();
        }
    }
}
