using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.domain
{
    public class BabyProfile
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Birth { get; set; } = string.Empty;

        public int InicialWeight { get; set; }

        public int ActualWeight { get; set; }

        public int Size { get; set; }


    }
}
