using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using ProjectConstants;

namespace CSVProcessorDomain
{
    //Using | as a delimiter, can be changed to other delimiters like comma
    //FileHelper is a 3rd party dll that helps in processing csv records and also flagging errors based on the attributes decorated for each column
    [DelimitedRecord(CSVConstants.FileDelimiter)]
    public class CustomerDataModel : IFileHelperModel
    {
        [FieldNotEmpty]
        [FieldTrim(TrimMode.Both)]
        public string CustomerId { get; set; }

        [FieldTrim(TrimMode.Both)]
        public string CustomerFirstName { get; set; }

        [FieldTrim(TrimMode.Both)]
        public string CustomerLastName { get; set; }

        [FieldTrim(TrimMode.Both)]
        public string PhoneNumber { get; set; }

    }
   }
