using CSVProcessorDomain;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using ProjectConstants;

namespace FileProcessorBusinessLayer
{
    public class FileReader
    {
        Dictionary<string, string> fileTypeMapperDictionary = new Dictionary<string, string>();
        IBusinessProcessor businessProcessor = null;
        public FileReader(IBusinessProcessor businessProcessor)
        {
            this.fileTypeMapperDictionary.Add("Customer", "CSVProcessorDomain.CustomerDataModel");
            this.fileTypeMapperDictionary.Add("Order", "CSVProcessorDomain.OrderDataModel");
            this.businessProcessor = businessProcessor;


        }
        public void ProcessFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(ConfigurationManager.AppSettings[CSVConstants.FilePathLookup]);
            FileInfo[] files = directoryInfo.GetFiles(CSVConstants.FileExtension);
            foreach(var file in files)
            {
                string fileTypeClass = this.fileTypeMapperDictionary[Path.GetFileNameWithoutExtension(file.Name)];
                ErrorInfo[] errorInfo = null;
                List<object> processedRecords = this.businessProcessor.ProcessCSVData(fileTypeClass, file.FullName, out errorInfo);

                //Call EF DAL layer to insert processed records
            }
        }
    }
}
