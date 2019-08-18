using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.Models;
using System.Data.Entity;

namespace CustomerInquiry.Tests
{
    class TestCustomerInquiryContext : ICustomerInquiry
    {
        public TestCustomerInquiryContext()
        {
            this.Customers = new TestCustomerDbSet();
            this.Customers.Add(new Customer()
            {
                Id = 1,
                Name = "FirstnameA LastnameA",
                Email = "userA@domain.com",
                MobileNumber = "084323433",
                Transactions = new List<Transaction>(){
                            new Transaction(){
                                Id=1,
                                TransactionDate = new DateTime(2019,06,20,21,34,00),
                                Amount =1000.25M,
                                CurrencyCode = "USD",
                                Status = TransactionStatus.Success
                            }
                        }
            });
            this.Customers.Add(new Customer()
            {
                Id = 2,
                Name = "FirstnameB LastnameB",
                Email = "userB@domain.com",
                MobileNumber = "0123456789",
                Transactions = null
                        
            });
            this.Customers.Add(new Customer()
            {
                Id = 3,
                Name = "FirstnameC LastnameC",
                Email = "userC@domain.com",
                MobileNumber = "0123456789",
                Transactions = new List<Transaction>(){
                            new Transaction(){
                                Id=1,
                                TransactionDate = new DateTime(2019,03,18,21,34,00),
                                Amount =1534.56M,
                                CurrencyCode = "USD",
                                Status = TransactionStatus.Success
                            },
                             new Transaction(){
                                Id=2,
                                TransactionDate = new DateTime(2019,03,18,20,34,00),
                                Amount =1534.56M,
                                CurrencyCode = "USD",
                                Status = TransactionStatus.Failed
                            }
                        }
            });

        }
        public DbSet<Customer> Customers { get; set; }


        public void MarkAsModified(Customer item) { }
        public void Dispose() { }


        public int SaveChanges()
        {
            return 0;
        }

        Task<int> ICustomerInquiry.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

