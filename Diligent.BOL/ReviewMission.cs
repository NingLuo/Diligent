using System;

namespace Diligent.BOL
{
    public class ReviewMission
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int TaskId { get; set; }
        public byte StatusId { get; set; }

        public virtual Task Task { get; set; }
        public virtual Status Status { get; set; }       
    }
}