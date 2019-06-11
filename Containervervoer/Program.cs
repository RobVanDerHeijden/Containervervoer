using System;
using Containervervoer2.Factorys;

namespace Containervervoer2
{
    public class Program
    {
        static void Main(string[] args)
        {
            FactoryData factory = new FactoryData();

            Console.WriteLine(Methodes.Methode(factory.DataOneFreelancer(), factory.DataAllFreelancers()));
            Console.ReadKey();
        }
    }
}