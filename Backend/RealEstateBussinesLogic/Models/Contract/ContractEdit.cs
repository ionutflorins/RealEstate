using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.Contract
{
    public class ContractEdit
    {
        public int ID { get; set; }
        public string ContractNumber { get; set; }
        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public int DeveloperID { get; set; }
        public int? PropertyID { get; set; }
    }
}
