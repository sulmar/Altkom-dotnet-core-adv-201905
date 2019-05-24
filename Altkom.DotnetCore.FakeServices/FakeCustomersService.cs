using Altkom.DotnetCore.FakeServices.Fakers;
using Altkom.DotnetCore.IServices;
using Altkom.DotnetCore.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.FakeServices
{
    public class CustomerOptions
    {
        public int Qty { get; set; }
    }

    public class FakeCustomersService : ICustomersService
    {
        private readonly ICollection<Customer> customers;

        private readonly CustomerFaker customerFaker;

        // add package Microsoft.Extensions.Options

        //public FakeCustomersService(CustomerFaker customerFaker, IOptions<CustomerOptions> options)
        //{
        //    this.customerFaker = customerFaker;

        //    customers = customerFaker.Generate(options.Value.Qty);
        //}

        public FakeCustomersService(CustomerFaker customerFaker, CustomerOptions options)
        {
            this.customerFaker = customerFaker;

            customers = customerFaker.Generate(options.Qty);
        }

        public void Add(Customer entity) => customers.Add(entity);

        public IEnumerable<Customer> Get() => customers;

        public Customer Get(int id) => customers.SingleOrDefault(p => p.Id == id);

        public void Remove(int id) => customers.Remove(Get(id));

        public void Update(Customer entity)
        {            
            throw new NotImplementedException();
        }
    }
}
