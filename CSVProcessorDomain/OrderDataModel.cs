using FileHelpers;
using ProjectConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVProcessorDomain
{
    //Using | as a delimiter, can be changed to other delimiters like comma
    //FileHelper is a 3rd party dll that helps in processing csv records and also flagging errors based on the attributes decorated for each column
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
