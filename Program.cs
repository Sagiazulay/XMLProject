using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Car Mazda = new Car("Mazda", "3", 2008, "Yellow", 1234, 4);
            Car.SerializeACar(@"c:\temp\xmlfile.xml", Mazda);

            Car Fiat;
            Fiat = Car.DeserializeACar(@"c:\temp\xmlfile.xml") as Car;
            Console.WriteLine(Fiat.ToString());

            Car[] cars = new Car[]
            {
                new Car("Mercedes", "GLA", 2019, "White", 4545, 2),
                new Car("Chevrolet", "Optra", 2008, "Grey", 1388, 5),
                new Car("Fiat", "500", 2015, "Red", 008, 4)
            };
            Car.SerializeACarArray(@"c:\temp\xmlarrayfile.xml", cars);

            Car[] NewArray;
            NewArray = Car.DeserializeACarArray(@"c:\temp\xmlarrayfile.xml");
            foreach (var item in NewArray)
            {
                Console.WriteLine(item);
            }
            

        }
    }
}
