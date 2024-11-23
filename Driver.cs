
namespace InventoryManagementSystem
{
    public class Driver
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string TruckNumber { get; set; }
        public DateTime DateTime { get; set; }

        public Driver(string name, string company, string truckNumber, DateTime dateTime)
        {
            Name = name;
            Company = company;
            TruckNumber = truckNumber;
            DateTime = dateTime;
        }
    }
}





/*using System;

namespace InventoryManagementSystem.Models
{
    public class Driver // denna är driver klass som registrerar föraren 
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string TruckNumber { get; set; }
        public DateTime DateTime { get; set; }

        public Driver(string name, string company, string truckNumber, DateTime dateTime)
        {
            Name = name;
            Company = company;
            TruckNumber = truckNumber;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"Driver: {Name}, Company: {Company}, Truck: {TruckNumber}, Date/Time: {DateTime}";
        }
    }
}
