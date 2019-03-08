using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FileProcessorEFDALLayer;

namespace FileProcessorEF
{
    public class EntityDataRetriever
    {
        public IEnumerable<CustomerOrder> GetCustomerOrderData()
        {           
            using (CustomerOrderDBContext dBContext = new CustomerOrderDBContext())
            {
                return (from c in dBContext.Customers
                            join o in dBContext.Orders on c.CustomerId equals o.OrderCustomerId
                            select new CustomerOrder()
                            {
                                CustomerFirstName = c.CustomerFirstName,
                                CustomerLastName = c.CustomerLastName,
                                OrderId = o.OrderId,
                                OrderCustomerId = o.OrderCustomerId
                            } ).ToList();
            }
        }



    }
}
