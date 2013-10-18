using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Fitlife.Domain.Entities
{
    public class BodyPhoto
    {
        [Key]
        public int PhotoID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
        public string PhotoSource { get; set; }
        public string PhotoDescription { get; set; }

        public string MuscleGroup { get; set; }
    }
}
