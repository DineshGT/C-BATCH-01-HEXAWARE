using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    public class Patient
    {

        // Fields/attributes..
        private int patientId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string contactNumber;
        private string address;

        // Default constructor
        public Patient() { }

        // Parameterized constructor
        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactNumber, string address)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        // Properties (getters and setters)
        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        //we can also use lambda functions..
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Gender { get => gender; set => gender = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Address { get => address; set => address = value; }

        
        // ToString method using overriding ..
        public override string ToString()
        {
            return $"PatientId: {patientId}, Name: {firstName} {lastName}, DOB: {dateOfBirth.ToShortDateString()}, " +
                $"Gender: {gender}, Contact: {contactNumber}, Address: {address}";
        }

    }
}
