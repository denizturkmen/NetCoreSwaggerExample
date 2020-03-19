using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreSwaggerUI.Entities;

namespace NetCoreSwaggerUI.DataAccess.Abstract
{
    public interface IPersonDal:IRepositoryDal<Person>
    {
        
    }
}
