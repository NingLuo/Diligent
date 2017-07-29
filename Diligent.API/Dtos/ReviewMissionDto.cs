using System;

namespace Diligent.API.Dtos
{
    public class ReviewMissionDto
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int TaskId { get; set; }
        public byte StatusId { get; set; }

        public virtual TaskDto Task { get; set; }
        public virtual StatusDto Status { get; set; }
    }
}