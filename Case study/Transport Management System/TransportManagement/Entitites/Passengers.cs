using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Entities
{
    public class Passengers
    {
        // Fields
        private int Passenger_id;
        private string? First_name;
        private string? Gender;
        private int Age;
        private string? Email;
        private string? Phone_number;

        // Default Constructor
        public Passengers() { }

        // Parameterized Constructor
        public Passengers(int passenger_id, string first_name, string gender, int age, string email, string phone_number)
        {
            Passenger_id = passenger_id;
            First_name = first_name;
            Gender = gender;
            Age = age;
            Email = email;
            Phone_number = phone_number;
        }

        // Getters and Setters
        public int GetPassenger_id() => Passenger_id;
        public void SetPassenger_id(int passenger_id) => Passenger_id = passenger_id;

        public string? GetFirst_name() => First_name;
        public void SetFirst_name(string first_name) => First_name = first_name;

        public string? GetGender() => Gender;
        public void SetGender(string gender) => Gender = gender;

        public int GetAge() => Age;
        public void SetAge(int age) => Age = age;

        public string? GetEmail() => Email;
        public void SetEmail(string email) => Email = email;

        public string? GetPhone_number() => Phone_number;
        public void SetPhone_number(string phone_number) => Phone_number = phone_number;
    }
}
