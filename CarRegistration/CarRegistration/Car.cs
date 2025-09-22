using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistration
{
    public class Car
    {
        string LicensePlate { get; set; }
        string Type { get; set; }
        string Color { get; set; }
        int ManufactureYear { get; set; }
        double Price { get; set; }

        public Car(string licensePlate, string type, string color, int manufactureYear, double price)
        {
            LicensePlate = licensePlate;
            Type = type;
            Color = color;
            ManufactureYear = manufactureYear;
            Price = price;
        }

        public override string ToString()
        {
            return $"License Plate: {LicensePlate}, Type: {Type}, Color: {Color}, Manufacture Year: {ManufactureYear}, Price: {Price}";
        }
    }
}
