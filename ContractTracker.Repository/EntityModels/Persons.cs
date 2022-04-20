using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Persons
    {
        [Key]
        public int PersonId { get; set; }
        public int? UnitId { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPhoneNumber { get; set; }
        public bool Active { get; set; }
        public int ContactLKID { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
