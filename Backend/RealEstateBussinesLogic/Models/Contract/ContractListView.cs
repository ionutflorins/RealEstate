﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.Contract
{
    public class ContractListView
    {
        public int ID { get; set; }
        public string ContractNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
