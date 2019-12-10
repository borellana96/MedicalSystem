using FarmaciaBE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaDA
{
    public class ContextDA : DbContext
    {
        public ContextDA() : base("ConexionBD")
        {
            Database.SetInitializer(new CargaInicialBD());

            if (!this.Database.Exists()) this.Database.Initialize(true);

            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ClienteBE> DbCliente { set; get; }
        public DbSet<FarmaceuticoBE> DbFarmaceutico { set; get; }
        public DbSet<ProductoBE> DbProducto { set; get; }
        public DbSet<PedidoBE> DbPedido { set; get; }
        public DbSet<VentaBE> DbVenta { set; get; }
        public DbSet<DetalleVentaBE> DbDetalleVenta { set; get; }
    }
}
