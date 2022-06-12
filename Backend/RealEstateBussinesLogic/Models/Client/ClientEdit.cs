using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.Client
{
    public class ClientEdit
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalID { get; set; }
        public string SerieNo { get; set; }
        public string Address { get; set; }
        public string IssuedBy { get; set; }
        public DateTime Validity { get; set; }
        public int DeveloperID { get; set; }
        public string AppUserID { get; set; }
    }
}
