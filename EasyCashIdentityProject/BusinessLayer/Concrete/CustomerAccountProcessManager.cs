using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }
        public void TDelete(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Delete(entity);
        }

        public List<CustomerAccountProcess> TGetAll()
        {
            return _customerAccountProcessDal.GetAll();
        }

        public CustomerAccountProcess? TGetById(int id)
        {
            return _customerAccountProcessDal.GetById(id);
        }

        public void TInsert(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Insert(entity);
        }

        public void TUpdate(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Update(entity);
        }
    }
}