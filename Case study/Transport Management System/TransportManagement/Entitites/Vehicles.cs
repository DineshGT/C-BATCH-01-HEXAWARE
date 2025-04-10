using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Entities
{
    //vehicles class starts
    public class Vehicles
    {

        // Fields
        private int Vehicle_id;
        private string? Model_name;
        private decimal Capacity;
        private string? Type;
        private string? Status;

        // Default Constructor
        public Vehicles() { }

        // Parameterized Constructor
        public Vehicles(int vehicle_id, string model_name, decimal capacity, string type, string status)
        {
            Vehicle_id = vehicle_id;
            Model_name = model_name;
            Capacity = capacity;
            Type = type;
            Status = status;
        }

        // Getters and Setters 
        public int GetVehicle_id() => Vehicle_id;
        public void SetVehicle_id(int vehicle_id) => Vehicle_id = vehicle_id;

        public string? GetModel_name() => Model_name;
        public void SetModel_name(string model_name) => Model_name = model_name;

        public decimal GetCapacity() => Capacity;
        public void SetCapacity(decimal capacity) => Capacity = capacity;

        public string? GetType() => Type;
        public void SetType(string type) => Type = type;

        public string? GetStatus() => Status;
        public void SetStatus(string status) => Status = status;

    }
}
