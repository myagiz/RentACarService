using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }
    }
}
