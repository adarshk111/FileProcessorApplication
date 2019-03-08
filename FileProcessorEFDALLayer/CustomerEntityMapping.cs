using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FileProcessorEFDALLayer;

namespace FileProcessorEF
{
    public class CustomerEntityMapping : IEntityMapping
    {
        public void CreateEntityMapping(List<object> fileHelperModel)
        {
            //Initializing Automapper for anonymous type usage as the source is not known during compile time
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
            });
            var mapper = config.CreateMapper();

            //Conversion of object list into DBEntity Model
            List<Customer> clist = fileHelperModel.Select(mapper.Map<Customer>).ToList();

            using (CustomerOrderDBContext dBContext = new CustomerOrderDBContext())
            {
                foreach (Customer c in clist)
                {
                    dBContext.Customers.Add(c);
                }
                
                dBContext.SaveChanges();
            }
        }
    }
}
