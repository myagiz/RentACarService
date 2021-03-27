using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserDal
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
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
