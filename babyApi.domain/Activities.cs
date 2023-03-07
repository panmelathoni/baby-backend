using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.domain
{
    public class Activities
    {
        public int Id { get; set; }

        public string NameActivity { get; set; } = string.Empty;

        public string CodeActivity { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;
    }
}
