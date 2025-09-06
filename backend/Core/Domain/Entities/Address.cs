namespace Domain
{
    public class Address
    {
        public string PostalCode { get; private set; }
        public string AddressLine { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        
        public Address(string postalCode, string addressLine, string number, string complement, string neighborhood, string city, string state)
        {
            PostalCode = postalCode;
            AddressLine = addressLine;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public void UpdatePostalCode(string postalCode)
        {
            PostalCode = postalCode;
        }

        public void UpdateAddressLine(string addressLine)
        {
            AddressLine = addressLine;
        }

        public void UpdateNumber(string number)
        {
            Number = number;
        }

        public void UpdateComplement(string complement)
        {
            Complement = complement;
        }

        public void UpdateNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;
        }

        public void UpdateCity(string city)
        {
            City = city;
        }
        
        public void UpdateState(string state)
        {
            State = state;
        }
    }
}

