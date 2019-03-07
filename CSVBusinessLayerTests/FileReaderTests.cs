using System;
using System.Collections.Generic;
using System.Configuration;
using FileHelpers;
using FileProcessorBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectConstants;
using Rhino.Mocks;

namespace FileProcessorBusinessLayerTests
{
    [TestClass]
    public class FileReaderTests
    {
        IBusinessProcessor businessProcessor;
        FileReader reader;
        public FileReaderTests()
        {
            this.businessProcessor = MockRepository.GenerateMock<IBusinessProcessor>();
            this.reader = MockRepository.GeneratePartialMock<FileReader>(this.businessProcessor);
        }
        
        
        [TestMethod]
        public void ProcessFiles_Should_Process_CustomerDataModel()
        {
            ErrorInfo[] errorInfo;
            this.businessProcessor.Expect(x => x.ProcessCSVData("CSVProcessorDomain.CustomerDataModel", ConfigurationManager.AppSettings[CSVConstants.FilePathLookup], out errorInfo)).IgnoreArguments().Return(new List<object>());
           this.reader.ProcessFiles();
           
        }


    }
}
