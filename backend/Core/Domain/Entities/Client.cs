using System;

namespace Domain
{
    public class Client : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }

        public Client() { }

        public Client(string firstName, string lastName, string phoneNumber, string email, string documentNumber, DateTime birthDate, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            DocumentNumber = documentNumber;
            BirthDate = birthDate;
            Address = address;
        }

        public void UpdateFirstName(string name)
        {
            FirstName = name;
        }

        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void UpdateDocumentNumber(string documentNumber)
        {
            DocumentNumber = documentNumber;
        }
        
        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
    }
}
