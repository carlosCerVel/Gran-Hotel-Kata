using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GranHotelKata.Main
{
    [Table("Room")]
    public class CheckOutEvent : FullAuditedEntity<long>
    {
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public bool CheckOutDateDiscrepancyDetected { get; set; }
        public string Comments { get; set; }
    }
}
