﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAuto.Models
{
    public class ColorVehicle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ColorId")]
        public int ColorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}