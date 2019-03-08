using CSVProcessorDomain;
using FileHelpers;
using System;
using System.Collections.Generic;
using FileProcessorEF;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using ProjectConstants;
using Unity;


namespace FileProcessorBusinessLayer
{
    public class FileReader
    {
        Dictionary<string, string> fileTypeMapperDictionary = new Dictionary<string, string>();
        IBusinessProcessor businessProcessor = null;
        private static IUnityContainer custs = null;
        EntityDataRetriever edr = new EntityDataRetriever();
        public FileReader(IBusinessProcessor businessProcessor)
        {
            //FileName - FileHelper class mapping. This can also be pulled from Database or any external configuration
            this.fileTypeMapperDictionary.Add("Customer", "CSVProcessorDomain.CustomerDataModel");
            this.fileTypeMapperDictionary.Add("Order", "CSVProcessorDomain.OrderDataModel");
            this.businessProcessor = businessProcessor;


        }
        public void ProcessFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(ConfigurationManager.AppSettings[CSVConstants.FilePathLookup]);
            FileInfo[] files = directoryInfo.GetFiles(CSVConstants.FileExtension);
            foreach (var file in files)
            {
                if (this.fileTypeMapperDictionary.ContainsKey(Path.GetFileNameWithoutExtension(file.Name)))
                {
                    string fileTypeClass = this.fileTypeMapperDictionary[Path.GetFileNameWithoutExtension(file.Name)];
                    ErrorInfo[] errorInfo = null;
                    List<object> processedRecords = this.businessProcessor.ProcessCSVData(fileTypeClass, file.FullName, out errorInfo);

                    //Creating Instance using Factory Pattern
                    IEntityMapping entity = ObjectFactory.CreateFactoryInstance(fileTypeClass);
                    
                    //Processing records for DB insert. Only at run time, the corresponding class is known - Order or Customer
                    entity.CreateEntityMapping(processedRecords);                 

                }                
                else
                {
                    throw new Exception("Invalid FileName. Not found in repository");
                }
            }

            //Fetch Order and Customer mapping records from DB
            IEnumerable<CustomerOrder> dataset = edr.GetCustomerOrderData();
        }


    }
}
