using System;
using System.Collections.Generic;
using FileHelpers;
using FileProcessorBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileProcessorBusinessLayerTests
{
    [TestClass]
    public class BusinessProcessorTests
    {
        BusinessProcessor businessProcessor = new BusinessProcessor();
        private string FullCustomerFilePath;
        private string FullOrderFilePath;
        public BusinessProcessorTests()
        {
            FullCustomerFilePath = @"C:\Users\Adarsh Kediyoor\source\repos\CSVProcessorConsole\CSVProcessorConsole\Files\Customer.csv";
            FullOrderFilePath = @"C:\Users\Adarsh Kediyoor\source\repos\CSVProcessorConsole\CSVProcessorConsole\Files\Order.csv";
        } 

        [TestMethod]
        public void ProcessCSVData_Should_Return_ValidList_For_CustomerDataModel()
        {
           ErrorInfo[] errorInfo = null;
           List<object> validRecordList = businessProcessor.ProcessCSVData("CSVProcessorDomain.CustomerDataModel", FullCustomerFilePath, out errorInfo);
           Assert.IsTrue(validRecordList.Count > 0);
        }

        [TestMethod]
        public void ProcessCSVData_Should_Return_ValidList_For_OrderDataModel()
        {
            ErrorInfo[] errorInfo = null;
            List<object> validRecordList = businessProcessor.ProcessCSVData("CSVProcessorDomain.OrderDataModel", FullOrderFilePath, out errorInfo);
            Assert.IsTrue(validRecordList.Count > 0);
        }
    }
}
