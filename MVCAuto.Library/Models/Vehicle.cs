using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAuto.Library.Models
{
    public enum Color
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Brown,
        Magenta,
        Black,
        White
    }


    public class Vehicle
    {
        public int ID { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Vin cannot be longer than 17 characters.")]
        public string Vin { get; set; }
        [Required]
        // public Color Color { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public DateTime OperDate { get; set; } = DateTime.UtcNow;
        public long IntRowVer { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public int ColorId { get; set; }
        public virtual ColorVehicle ColorVehicle { get; set; }

    }
}
