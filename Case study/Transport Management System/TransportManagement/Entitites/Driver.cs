using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Entities
{
    public class Drivers
    {
        // Fields
        private int Driver_id;
        private string? First_name;
        private string? Last_name;
        private string? License_number;
        private string? Phone_number;
        private string? Email;
        private int Experience_years;

        // Default Constructor
        public Drivers() { }

        // Parameterized Constructor
        public Drivers(int driver_id, string first_name, string last_name, string license_number,
                       string phone_number, string email, int experience_years)
        {
            Driver_id = driver_id;
            First_name = first_name;
            Last_name = last_name;
            License_number = license_number;
            Phone_number = phone_number;
            Email = email;
            Experience_years = experience_years;
        }

        // Getters and Setters
        public int GetDriver_id() => Driver_id;
        public void SetDriver_id(int driver_id) => Driver_id = driver_id;

        public string? GetFirst_name() => First_name;
        public void SetFirst_name(string first_name) => First_name = first_name;

        public string? GetLast_name() => Last_name;
        public void SetLast_name(string last_name) => Last_name = last_name;

        public string? GetLicense_number() => License_number;
        public void SetLicense_number(string license_number) => License_number = license_number;

        public string? GetPhone_number() => Phone_number;
        public void SetPhone_number(string phone_number) => Phone_number = phone_number;

        public string? GetEmail() => Email;
        public void SetEmail(string email) => Email = email;

        public int GetExperience_years() => Experience_years;
        public void SetExperience_years(int experience_years) => Experience_years = experience_years;

    }
}
