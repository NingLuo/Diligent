using System.Collections.Generic;
using System.Linq;
using Diligent.BOL;
using Diligent.DAL.Core;

namespace Diligent.BLL
{
    public class UserBs : BLLBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBs(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        } 

        public User GetUserById(int id)
        {
            return _unitOfWork.Users.Get(id);
        }

        public User Login(User user)
        {
            var userInDb = _unitOfWork.Users.SingleOrDefault(u => u.Email == user.Email);

            if (userInDb == null)
            {
                ErrorList.Add("User account with this email does not exist");
                return null;
            }

            if (userInDb.Password != user.Password)
            {
                ErrorList.Add("Password is not corret");
                return null;
            }

            return userInDb;
        }

        public bool CreateUser(User user)
        {
            if (!IsValidOnCreate(user)) return false;

            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            return true;
        }

        private bool IsValidOnCreate(User user)
        {
            //Unique Email Validation
            var email = user.Email;
            var count = GetAll().Count(u => u.Email == email);
            if (count != 0)
            {
                ErrorList.Add("This Email Already Exists");
            }

            return ErrorList.Count == 0;
        }
    }
}
