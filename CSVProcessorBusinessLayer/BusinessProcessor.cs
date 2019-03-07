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
    public class BusinessProcessor : IBusinessProcessor
    {
        public List<object> ProcessCSVData(string fileClass, string fullFilePath, out ErrorInfo[] erroredRecords)
        {
            Assembly asm = typeof(IFileHelperModel).Assembly;
            Type type = asm.GetType(fileClass);
            var engine = new DelimitedFileEngine(type);
            engine.Options.IgnoreFirstLines = 1;

            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
            List<object> processedCSVRecords = engine.ReadFile(fullFilePath).ToList();
            erroredRecords = engine.ErrorManager.Errors;

            return processedCSVRecords;
        }
    }
}
