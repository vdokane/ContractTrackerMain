using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Services.Business.Models
{
    public class UserUnitModel
    {
        public int UserUnitId { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int EndDate { get; set; }
    }
}
