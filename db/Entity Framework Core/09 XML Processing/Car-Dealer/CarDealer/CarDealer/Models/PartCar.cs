using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
public    class PartCar : IEquatable<PartCar>
    {
        [ForeignKey("Car")]
        public int CarId { get; set; }

        public Car Car { get; set; }
        [ForeignKey("Part")]
        public int PartId { get; set; }
        public Part Part { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PartCar);
        }

        public bool Equals(PartCar other)
        {
            return other != null &&
                   CarId == other.CarId &&
                   PartId == other.PartId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CarId, PartId);
        }


    }
}
