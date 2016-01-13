using System;
using System.Collections.Generic;

namespace CSVKata
{
    public class DebugCapturer 
    {
        private readonly ICustomerCapturer _customerCapturer;

        public DebugCapturer(ICustomerCapturer customerCapturer)
        {
            _customerCapturer = customerCapturer;
        }

        public void CaptureDebug(List<Customer> customers, string stuff, int batchSize, int debugBatchSize)
        {
            _customerCapturer.Capture(customers, stuff, batchSize);
            _customerCapturer.Capture(customers, stuff+".debug", debugBatchSize);
        }
    }
}