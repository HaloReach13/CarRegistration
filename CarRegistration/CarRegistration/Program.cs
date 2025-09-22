using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistration
{
    internal class Program
    {
        const string fileName = "data.dat";

        static void Main(string[] args)
        {
            SaveCarsBinary();
            List<Car> cars = LoadCarsBinary(fileName);
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            Console.ReadKey();
        }

        public static void SaveCarsBinary()
        {
            Console.Write("Enter License Plate: ");
            string licensePlate = Console.ReadLine();
            Console.Write("Enter Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Color: ");
            string color = Console.ReadLine();
            Console.Write("Enter Manufacture Year: ");
            int manufactureYear = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            using (var stream = File.Open(fileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(licensePlate);
                    writer.Write(type);
                    writer.Write(color);
                    writer.Write(manufactureYear);
                    writer.Write(price);
                }
            }
        }

        public static List<Car> LoadCarsBinary(string fileName)
        {
            List<Car> cars = new List<Car>();
            if (File.Exists(fileName))
            {
                BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open));
                string line = reader.ReadString();
                while (line != null)
                {
                    string[] parts = line.Split(',');
                    string licensePlate = parts[0];
                    string type = parts[1];
                    string color = parts[2];
                    int manufactureYear = int.Parse(parts[3]);
                    double price = double.Parse(parts[4]);
                    Car car = new Car(licensePlate, type, color, manufactureYear, price);
                    cars.Add(car);
                }

                reader.Close();
            }
            return cars;
        }
    }
}
