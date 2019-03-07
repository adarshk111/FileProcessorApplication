using CSVProcessorDomain;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessorBusinessLayer
{
    public interface IBusinessProcessor
    {
        List<object> ProcessCSVData(string fileClass, string fullFilePath, out ErrorInfo[] erroredRecords);
    }
}
