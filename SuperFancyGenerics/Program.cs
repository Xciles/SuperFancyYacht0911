using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperFancyGenerics
{
    public abstract class Animal
    {
        public abstract void Bla();
    }

    public class Dog : Animal
    {
        public override void Bla()
        {
            throw new NotImplementedException();
        }
    }

    public class Cat : Animal
    {
        public override void Bla()
        {
            throw new NotImplementedException();
        }
    }

    public class TempClass<TResult> where TResult : new()
    {
        public TResult Result { get; set; }

        public TResult GetResult()
        {
            //return default(TResult);
            return new TResult();
        }
    }

    class Program
    {
        private static void Bla<TAnimal>(TAnimal animal)
            where TAnimal : Animal
        {
            //animal.Bla();
        }

        private static async Task<TResult> GetEntityFromApi<TResult>(string uri)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        private static async Task<Dog> GetDogFromApi(string uri)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Dog>(result);
            }
        }
        private static async Task<T> GetCatFromApi<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<T>(result);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var temp = new TempClass<Dog>();
            var res = temp.GetResult();

            ArrayList ar = new ArrayList();
            ar.Add("");
            ar.Add(1);
            ar.Add(new Dog());

            foreach (object obj in ar)
            {
                if (obj is int i)
                {

                }
                else if (obj is string s)
                {

                }
            }

            var list = new List<string>();

            foreach (var s in list)
            {

            }
            foreach (var s in MyList())
            {

            }

            

            Console.ReadKey();
        }

        private static IEnumerable<string> MyList()
        {
            //return new List<string>();

            var client = new HttpClient();
            var result = client.GetStringAsync("https://www.").Result;
            yield return result;
            yield return result;
            yield return result;


            yield return result;
            yield return result;
            yield return result;
        }


    }
}
