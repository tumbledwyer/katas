using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace CSVKata
{
    public class CustomerCapturer
    {
        private readonly ICsvWriter _csvWriter;
        private readonly ISerialiser _serialiser;
        private readonly IDataCleaner _dataCleaner;

        public CustomerCapturer(ICsvWriter csvWriter, ISerialiser serialiser, IDataCleaner dataCleaner)
        {
            if (csvWriter == null) throw new ArgumentNullException(nameof(csvWriter));
            if (serialiser == null) throw new ArgumentNullException(nameof(serialiser));
            _csvWriter = csvWriter;
            _serialiser = serialiser;
            _dataCleaner = dataCleaner;
        }

        public void Capture(List<Customer> customers, string fileName, int batchSize)
        {
            var uniqueEntries = _dataCleaner.RemoveDuplicates(customers);

            for(var i = 0; i < uniqueEntries.Count; i++)
            {
                var fileNumber = (i/batchSize)+1;
                _csvWriter.Save($"{fileName}.{fileNumber}", _serialiser.SerialiseCustomer(customers.ElementAt(i)));
            }
        }
    }
}