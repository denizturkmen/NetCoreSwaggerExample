using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreSwaggerUI.Business.Abstract;
using NetCoreSwaggerUI.DataAccess.Abstract;
using NetCoreSwaggerUI.Entities;

namespace NetCoreSwaggerUI.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public Person GetById(int id)
        {
            return _personDal.GetById(id);
        }

        public void Create(Person entity)
        {
            _personDal.Create(entity);
        }

        public void Update(Person entity)
        {
            _personDal.Update(entity);
        }

        public void Delete(Person entity)
        {
            _personDal.Delete(entity);
        }
    }
}
