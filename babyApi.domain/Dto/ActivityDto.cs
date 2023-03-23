using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.domain.Dto
{
    public  class ActivityDto
    {
        public int IdDto { get; set; }

        public string NameActivityDto { get; set; } = string.Empty;

        public string CodeActivityDto { get; set; } = string.Empty;

        public string IconDto { get; set; } = string.Empty;

    }
}
