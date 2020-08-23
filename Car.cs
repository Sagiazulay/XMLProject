using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLProject
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        private int codan;

        public int Codan
        {
            get { return codan; }
            set { codan = value; }
        }
        protected int numberOfSeats = 4;

        public Car()
        {
                
        }
        //public Car(FileName fileName)
       // {

        //}

        public Car(string model, string brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            Codan = codan;
            this.numberOfSeats = numberOfSeats;
        }
        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }
        protected void ChangeNumberOfSeats(int newNumber)
        {
            if(newNumber > 0)
            {
                newNumber = numberOfSeats;
            }
        }
        public static void SerializeACar(string filename, Car car)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));

            using (Stream file = new FileStream(filename, FileMode.Create))
            {
                xmlSerializer.Serialize(file, car);
            }
        }
        public static void SerializeACarArray(string filename, Car [] cars)
        {
            XmlSerializer xmlSerializerArray = new XmlSerializer(typeof(Car[]));

            using (Stream file = new FileStream(filename, FileMode.Create))
            {
                xmlSerializerArray.Serialize(file, cars);
            }
        }
        public static Car DeserializeACar(string filename)
        {
            Car result = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));

            using (Stream file = new FileStream(filename, FileMode.Open))
            {
                result = xmlSerializer.Deserialize(file) as Car;
            }
            return result;
        }
        public static Car [] DeserializeACarArray(string filename)
        {
            Car[] cars = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car[]));

            using (Stream file = new FileStream(filename, FileMode.Open))
            {
                cars = xmlSerializer.Deserialize(file) as Car[];
            }
            return cars;
        }
        public override string ToString()
        {
            return $"Car Modle : {this.Model} Brand : {this.Brand} Year : {this.Year} Color : {this.Color}";
        }
    }
}
