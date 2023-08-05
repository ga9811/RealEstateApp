using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class ScheduleModel
    {
        public int id { get; set; }
            public int agent_id { get; set; }
       public int client_id { get; set; }
        public string schedule_type { get; set; }
        public DateTime schedule_time { get; set;}
        public int property_id { get; set; }
        public string description { get; set; }
        public string agent_name { get; set; }
        public string client_name { get; set; }
    }
}
