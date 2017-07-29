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
