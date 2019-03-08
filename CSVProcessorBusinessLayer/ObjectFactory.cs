using CSVProcessorDomain;
using FileHelpers;
using FileProcessorEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FileProcessorBusinessLayer
{
    public static class ObjectFactory 
    {
        private static IUnityContainer registeredObjs = null;

        //Unity Container to register types and return class based on input string
        public static IEntityMapping CreateFactoryInstance(string fileTypeClass)
        {
            //Unity Container is initialized only once during the lifecycle.
            if (registeredObjs == null)
            {
                registeredObjs = new UnityContainer();
                registeredObjs.RegisterType<IEntityMapping, CustomerEntityMapping>("CSVProcessorDomain.CustomerDataModel");
                registeredObjs.RegisterType<IEntityMapping, OrderEntityMapping>("CSVProcessorDomain.OrderDataModel");
            }
            return registeredObjs.Resolve<IEntityMapping>(fileTypeClass);
        }
    }
}
