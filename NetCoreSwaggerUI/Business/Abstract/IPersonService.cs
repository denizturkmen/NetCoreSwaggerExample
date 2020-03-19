using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NetCoreSwaggerUI.Entities;

namespace NetCoreSwaggerUI.Business.Abstract
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person GetById(int id);
        void Create(Person entity);
        void Update(Person entity);
        void Delete(Person entity);
    }
}
