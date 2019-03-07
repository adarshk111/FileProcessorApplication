using FileProcessorBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVProcessorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader reader = new FileReader(new BusinessProcessor());
            reader.ProcessFiles();

        }
    }
}
