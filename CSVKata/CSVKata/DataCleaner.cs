using System.Collections.Generic;
using System.Linq;

namespace CSVKata
{
    public interface IDataCleaner
    {
        List<Customer> RemoveDuplicates(List<Customer> customers);
    }

    public class DataCleaner : IDataCleaner
    {
        public List<Customer> RemoveDuplicates(List<Customer> customers)
        {
            var uniqueList = new List<Customer>();
            foreach (var customer in customers)
            {
                if(!uniqueList.Any(s => s.Name == customer.Name && s.ContactNumber == customer.ContactNumber))
                    uniqueList.Add(customer);
            }
            return uniqueList;
        }
    }
}