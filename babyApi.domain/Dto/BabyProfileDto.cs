using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.domain.Dto
{
    public class BabyProfileDto
    {
        public int IdDto { get; set; }

        public int UserIdDto { get; set; }

        public string NameDto { get; set; } = string.Empty;

        public string BirthDto { get; set; } = string.Empty;

        public int InicialWeightDto { get; set; }

        public int ActualWeightDto { get; set; }

        public int SizeDto { get; set; }

        public virtual User User { get; set; }
    }
}
