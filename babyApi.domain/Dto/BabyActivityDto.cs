using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.domain.Dto
{
    public class BabyActivityDto
    {
        public int IdDto { get; set; }


        public DateTime InitialTimeDto { get; set; }
        public DateTime EndTimeDto { get; set; }


        public string DescriptionDto { get; set; } = string.Empty;

        public int ActivityIdDto { get; set; }

        public virtual Activity ActivitiesDto { get; set; }

        public int BabyProfileId { get; set; }

        public virtual BabyProfile Babies { get; set; }

    }
}
