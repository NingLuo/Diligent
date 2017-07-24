using Diligent.BOL;
using Diligent.DAL;

namespace Diligent.BLL
{
    public class UserBs : BLLBase
    {
        private readonly UnitOfWork _unitOfWork;

        public UserBs(DiligentContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public bool Register(User user)
        {
            if (!IsValidOnRegister(user)) return false;

            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            return true;
        }

        private bool IsValidOnRegister(User user)
        {
            return true;
        }
    }
}
