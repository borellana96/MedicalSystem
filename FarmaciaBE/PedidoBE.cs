using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBE
{
    [Table("Pedido")]
    public class PedidoBE
    {
        [Column("IDPEDIDO"), MaxLength(5), Key]
        public string IdPedido { set; get; }

        [Column("ESTADO")]
        public int Estado { set; get; }

        [Column("IDCLIENTE"), MaxLength(8), Required]
        public string ClienteID { set; get; }

        [Column("IDFARMACEUTICO"), MaxLength(4), Required]
        public string FarmaceuticoID { set; get; }

        [ForeignKey("ClienteID")]
        public virtual ClienteBE ClienteBE { set; get; }

        [ForeignKey("FarmaceuticoID")]
        public virtual FarmaceuticoBE FarmaceuticoBE { set; get; }
    }
}
