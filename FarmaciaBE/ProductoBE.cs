using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBE
{
    [Table("Producto")]
    public class ProductoBE
    {
        [Column("IDPRODUCTO"), MaxLength(5), Key]
        public string IdProducto { set; get; }

        [Column("NOMBRE"), MaxLength(30)]
        public string Nombre { set; get; }

        [Column("PRECIO")]
        public double Precio { set; get; }
        
        [Column("STOCK")]
        public int Stock { set; get; }
    }
}
