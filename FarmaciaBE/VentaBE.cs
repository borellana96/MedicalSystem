using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBE
{
    [Table("Venta")]
    public class VentaBE
    {
        [Column("IDVENTA"), MaxLength(5), Key]
        public string IdVenta { set; get; }

        [Column("FECHA")]
        public DateTime Fecha { set; get; }

        [Column("PEDIDOID"), MaxLength(5), Required]
        public string PedidoID { set; get; }

        [ForeignKey("PedidoID")]
        public virtual PedidoBE PedidoBE { set; get; }       
    }
}
