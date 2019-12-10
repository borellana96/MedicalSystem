using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBE
{
    [Table("Farmaceutico")]
    public class FarmaceuticoBE
    {
        [Column("IDFARMACEUTICO"), MaxLength(4), Key]
        public string IdFarmaceutico { set; get; }

        [Column("NOMBRE"), MaxLength(50)]
        public string Nombre { set; get; }

        [Column("APELLIDOP"), MaxLength(20)]
        public string ApellidoP { set; get; }

        [Column("APELLIDOM"), MaxLength(20)]
        public string ApellidoM { set; get; }
    }
}
