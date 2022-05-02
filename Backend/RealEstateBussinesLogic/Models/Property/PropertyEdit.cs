using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.Property
{
    public class PropertyEdit
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int RoomNo { get; set; }
        public string IdentityNo { get; set; }
        public string BuildingNo { get; set; }
        public string PropertySqm { get; set; }
        public string? LotSqm { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }

    }
}
