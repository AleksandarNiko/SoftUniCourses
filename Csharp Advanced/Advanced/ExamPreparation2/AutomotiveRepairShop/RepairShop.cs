using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; } 
        public List<Vehicle> Vehicles  { get; set; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicleRemove = Vehicles.Find(v => v.VIN == vin);
            if (vehicleRemove == null)
            {
                return false;
            }

            return Vehicles.Remove(vehicleRemove);
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return Vehicles.OrderBy(v => v.Mileage).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
