using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Entities
{
    //routes class starts
    public class Routes
    {
        // Fields
        private int Route_id;
        private string? Start_destination;
        private string? End_destination;
        private decimal Distance;

        // Default Constructor
        public Routes() { }

        // Parameterized Constructor
        public Routes(int route_id, string start_destination, string end_destination, decimal distance)
        {
            Route_id = route_id;
            Start_destination = start_destination;
            End_destination = end_destination;
            Distance = distance;
        }

        // Getters and Setters
        public int GetRoute_id() => Route_id;
        public void SetRoute_id(int route_id) => Route_id = route_id;

        public string? GetStart_destination() => Start_destination;
        public void SetStart_destination(string start_destination) => Start_destination = start_destination;

        public string? GetEnd_destination() => End_destination;
        public void SetEnd_destination(string end_destination) => End_destination = end_destination;

        public decimal GetDistance() => Distance;
        public void SetDistance(decimal distance) => Distance = distance;



    }
}
