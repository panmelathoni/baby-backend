using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.domain
{
    public class BabyActivities
    {

        public int Id { get; set; }
        public int BabyId { get; set; }

        public int ActivityId { get; set; }

        public DateTime InitialTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; } = string.Empty;

        public Activities Activities { get; set; }

        public BabyActivities BabyActivities { get; set; }
    }
}
