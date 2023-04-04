﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GranHotelKata.Main
{
    [Table("Room")]
    public class Room : FullAuditedEntity<long>
    {
        [Required]
        [MaxLength(40), MinLength(1)]
        public string RoomNumber { get; set; }
        [Required]
        public bool IsOccupied { get; set; }
        [ForeignKey("Guess")]
        public long GuessAssignedId { get; set; }
        public Guess GuessAssigned { get; set; }
    }
}
