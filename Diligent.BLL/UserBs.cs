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

        public bool CreateUser(User user)
        {
            if (!IsValidOnCreate(user)) return false;

            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            return true;
        }

        private bool IsValidOnCreate(User user)
        {
            return true;
        }
    }
}
