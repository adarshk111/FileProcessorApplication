using FileHelpers;
using ProjectConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVProcessorDomain
{
    [DelimitedRecord(CSVConstants.FileDelimiter)]
    public class OrderDataModel: IFileHelperModel
    {
        [FieldNotEmpty]
        [FieldTrim(TrimMode.Both)]
        public string OrderId { get; set; }

        [FieldTrim(TrimMode.Both)]
        public string OrderReferenceNumber { get; set; }

        [FieldTrim(TrimMode.Both)]
        public string OrderCustomerId { get; set; }

        [FieldTrim(TrimMode.Both)]
        public string OrderDate { get; set; }
    }
}
