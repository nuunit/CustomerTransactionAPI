using CustomerInquiry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiry.Tests
{
    class TestCustomerDbSet: TestDbSet<Customer>
    {
        public override Customer Add(Customer item)
        {
            return base.Add(item);
        }
        public override Customer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(customer => customer.Id == (int)keyValues.Single());
        }

       
    }
}
