using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class PropertyModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public int? square_feet { get; set; }
        public decimal? price { get; set; }
        public string address { get; set; }
        public int? bedrooms { get; set; }
        public int? bathrooms { get; set; }
        public int? year_of_build { get; set; }
        public string offer_type { get; set; }
        public string inspection_status { get; set; }
        public DateTime? inspection_date { get; set; }
        public string repair_status { get; set; }
        public DateTime? repair_date { get; set; }
        public byte[] photo { get; set; }
        public bool? balcony { get; set; }
        public bool? pool { get; set; }
        public bool? backyard { get; set; }
        public bool? garage { get; set; }
        public string description { get; set; }
        public int? client_id { get; set; }
    }
}
