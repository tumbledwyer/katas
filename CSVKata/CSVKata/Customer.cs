using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVKata
{
    public interface IFolder
    {
        void AppendLine(string fileName, string line);
    }

    public class Customer
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
    }
}
