using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBE
{
    [Table("Detalle_Venta")]
    public class DetalleVentaBE
    {
        [Column("NUM_DETALLE", Order =200), Key]
        public int NumDetalle { set; get; }

        [Column("CANTIDAD")]
        public int Cantidad { set; get; }

        [Column("PEDIDOID", Order =100), MaxLength(5), Required, Key]
        public string PedidoID { set; get; }

        [Column("PRODUCTOID"), MaxLength(5), Required]
        public string ProductoID { set; get; }

        [ForeignKey("PedidoID")]
        public PedidoBE PedidoBE { set; get; }

        [ForeignKey("ProductoID")]
        public ProductoBE ProductoBE { set; get; }

    }
}
