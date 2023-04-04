using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranHotelKata.Main
{
    [Table("Guess")]
    public class Guess : FullAuditedEntity<long>
    {
        [Required]
        [MaxLength(40), MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40), MinLength(1)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(20), MinLength(1)]
        public string ID { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        public bool CheckOutEventId { get; set; }
        [ForeignKey("CheckOutEventId")]
        public bool CheckOutEvent { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
    }
}
