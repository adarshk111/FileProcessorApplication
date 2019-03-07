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
    [DelimitedRecord(CSVConstants.FileDelimiter)]
    public class CustomerDataModel : IFileHelperModel
    {
        [FieldNotEmpty]
        [FieldTrim(TrimMode.Both)]
        private string CustomerId { get; set; }

        [FieldTrim(TrimMode.Both)]
        private string CustomerFirstName { get; set; }

        [FieldTrim(TrimMode.Both)]
        private string CustomerLastName { get; set; }

        [FieldTrim(TrimMode.Both)]
        private string PhoneNumber { get; set; }

    }
   }
