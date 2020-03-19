using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreSwaggerUI.DataAccess.Abstract;
using NetCoreSwaggerUI.Entities;

namespace NetCoreSwaggerUI.DataAccess.Concrete
{
    public class EfCorePersonDal:EfGenericRepositoryDal<Person,DatabaseContext>,IPersonDal
    {
        
    }
}
