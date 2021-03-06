﻿using System;
using System.Collections.Generic;

namespace Diligent.BOL
{
    public class Task
    {
        public Task()
        {
            ReviewMissions = new HashSet<ReviewMission>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }        
        public int ProjectId { get; set; }
        public byte StatusId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ReviewMission> ReviewMissions { get; set; }
    }
}
