using System;

namespace CSVKata
{
    public interface ISerialiser
    {
        string SerialiseCustomer(Customer customer);
    }

    public class Serialiser : ISerialiser
    {
        public string SerialiseCustomer(Customer customer)
        {
            if(string.IsNullOrEmpty(customer.ContactNumber))
                throw new ArgumentNullException("ContactNumber");
            if(string.IsNullOrEmpty(customer.Name))
                throw new ArgumentNullException("Name");

            return $"{customer.Name},{customer.ContactNumber}\n";
        }
    }


}