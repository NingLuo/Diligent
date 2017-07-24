using System.Collections.Generic;

namespace Diligent.BLL
{
    public class BLLBase
    {
        public BLLBase()
        {
            ErrorList = new List<string>();
        }

        public List<string> ErrorList { get; set; }
    }
}
