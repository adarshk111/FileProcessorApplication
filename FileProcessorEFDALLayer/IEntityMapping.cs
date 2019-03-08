using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessorEF
{
    public interface IEntityMapping
    {
         void CreateEntityMapping(List<object> model);        
    }
}
