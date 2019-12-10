using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBE
{
    [Table("Cliente")]
    public class ClienteBE
    {
        [Column("DNI"), MaxLength(8), Key]
        public string Dni { get; set; }

        [Column("NOMBRE"), MaxLength(50)]
        public string Nombre { get; set; }

        [Column("APELLIDOP"), MaxLength(20)]
        public string ApellidoP { get; set; }

        [Column("APELLIDOM"), MaxLength(20)]
        public string ApellidoM { get; set; }

        [Column("SEXO"), MaxLength(10)]
        public string Sexo { get; set; }

        [Column("DIRECCION"), MaxLength(120)]
        public string Direccion { get; set; }

        [Column("FECHA_NACIMIENTO")]
        public DateTime FechaNacimiento { get; set; }

    }
}
