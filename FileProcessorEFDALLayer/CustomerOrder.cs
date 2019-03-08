using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FileProcessorEFDALLayer;

namespace FileProcessorEF
{
    public class CustomerOrder
    {
        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set;  }

        public string OrderId { get; set; }

        public string OrderCustomerId { get; set; }

    }
}
