using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranHotelKata.Main
{
    [Table("Guess")]
    public class Guess : FullAuditedEntity<long>
    {
        [Key]
        public override long Id { get; set; }
        [Required]
        [MaxLength(40), MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40), MinLength(1)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(20), MinLength(1)]
        public string GuessID { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        public long? CheckOutEventId { get; set; }
        [ForeignKey("CheckOutEventId")]
        public CheckOutEvent CheckOutEvent { get; set; }

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
