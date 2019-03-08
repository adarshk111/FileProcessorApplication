using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FileProcessorEFDALLayer;

namespace FileProcessorEF
{
    //Separation of Order and Customer DB insertion responsibility using a common interface
    public class OrderEntityMapping : IEntityMapping
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
            List<Order> olist = fileHelperModel.Select(mapper.Map<Order>).ToList();

            using (CustomerOrderDBContext dBContext = new CustomerOrderDBContext())
            {
                foreach (Order o in olist)
                {
                    dBContext.Orders.Add(o);
                }

                dBContext.SaveChanges();
            }
        }



    }
}
