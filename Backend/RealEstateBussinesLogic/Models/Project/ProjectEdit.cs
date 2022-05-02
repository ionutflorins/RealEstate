using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.Project
{
    public class ProjectEdit
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? BuildingsNo { get; set; }
        public int? ApartmentNo { get; set; }
        public int? HouseNo { get; set; }
        public string Description { get; set; }
        public int DeveloperID { get; set; }
    }
}
