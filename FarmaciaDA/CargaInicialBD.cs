using FarmaciaBE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaDA
{
    public class CargaInicialBD : DropCreateDatabaseIfModelChanges<ContextDA>
    {
        protected override void Seed(ContextDA context)
        {
            try
            {
                /*IList<PerfilBE> Perfiles = new List<PerfilBE>()
                {
                    new PerfilBE() { IdPerfil = 1, Descripcion = "Administrador" },
                    new PerfilBE() { IdPerfil = 2, Descripcion = "Invitado" }
                };

                List<UsuarioBE> Usuarios = new List<UsuarioBE>()
                {
                    new UsuarioBE() { IdUsuario = 1, IdPerfil = 1,  Correo = "admin@mail.pe", Contrasenia = "admin123", Nombres = "Administrador", ApellidoPaterno = "", ApellidoMaterno = "" },
                    new UsuarioBE() { IdUsuario = 2, IdPerfil = 2, Correo = "invitado@mail.pe", Contrasenia = "invitado123", Nombres = "Invitado", ApellidoPaterno = "", ApellidoMaterno = "" }
                };*/

                List<ClienteBE> clientes = new List<ClienteBE>()
                {
                    new ClienteBE() {Dni="73524246", Nombre="Brian Gerard", ApellidoP="Orellana", ApellidoM="Ita", Sexo="Masculino", Direccion="Calle Federico Moore 140 - SMP", FechaNacimiento= DateTime.Parse("13/12/1996") },
                    new ClienteBE() {Dni="78421693", Nombre="Rinaldo", ApellidoP="Cruz", ApellidoM="Arteaga", Sexo="Masculino", Direccion="Av.Perú 3422 - SMP", FechaNacimiento= DateTime.Parse("01/02/1989")},
                    new ClienteBE() {Dni="09756631", Nombre="Lorena", ApellidoP="Navarro", ApellidoM="Perez", Sexo="Femenino", Direccion="Calle García 234 - Los Olivos", FechaNacimiento=DateTime.Parse("29/10/1975") },
                    new ClienteBE() {Dni="89420362", Nombre="Corina", ApellidoP="Angeles", ApellidoM="Roman", Sexo="Femenino", Direccion="Av. Universitaria 2900", FechaNacimiento=DateTime.Parse("15/06/1998") },
                    new ClienteBE() {Dni="64213995", Nombre="James", ApellidoP="Ccahuana", ApellidoM="Aliaga", Sexo="Masculino", Direccion="Jr.Iquitos 652", FechaNacimiento=DateTime.Parse("14/05/1993") },
                    new ClienteBE() {Dni="79260045", Nombre="Alyssa", ApellidoP="Mendez", ApellidoM="Sotelo", Sexo="Femenino", Direccion="Jr.Ancash 3712", FechaNacimiento=DateTime.Parse("28/07/1995") }/*,
                    new ClienteBE() {Dni="", Nombre="", ApellidoP="", ApellidoM="", Sexo="Masculino", Direccion="", FechaNacimiento=DateTime.Parse("") },
                    new ClienteBE() {Dni="", Nombre="", ApellidoP="", ApellidoM="", Sexo="Masculino", Direccion="", FechaNacimiento=DateTime.Parse("") },
                    new ClienteBE() {Dni="", Nombre="", ApellidoP="", ApellidoM="", Sexo="Masculino", Direccion="", FechaNacimiento=DateTime.Parse("") },
                    new ClienteBE() {Dni="", Nombre="", ApellidoP="", ApellidoM="", Sexo="Masculino", Direccion="", FechaNacimiento=DateTime.Parse("") },*/
                };

                List<FarmaceuticoBE> farmaceuticos = new List<FarmaceuticoBE>()
                {
                    new FarmaceuticoBE() { IdFarmaceutico="F001", Nombre="Jorge", ApellidoP="Luna", ApellidoM="Rivera"},
                    new FarmaceuticoBE() { IdFarmaceutico="F002", Nombre="Chapatin", ApellidoP="Chespirito", ApellidoM="Mercado"},
                    new FarmaceuticoBE() { IdFarmaceutico="F003", Nombre="Alisson", ApellidoP="Flores", ApellidoM="Gama"}
                };

                List<ProductoBE> productos = new List<ProductoBE>()
                {
                    new ProductoBE() {IdProducto="P0001",Nombre="Cetirizina", Precio= 0.30, Stock=100 },
                    new ProductoBE() {IdProducto="P0002",Nombre="Paracetamol 250g", Precio=0.20, Stock=200 },
                    new ProductoBE() {IdProducto="P0003",Nombre="Paracetamol 500g", Precio=0.40, Stock=183 },
                    new ProductoBE() {IdProducto="P0004",Nombre="Fluconazol", Precio=0.80, Stock=30 },
                    new ProductoBE() {IdProducto="P0005",Nombre="Metformina", Precio=1.10, Stock=50 },
                    new ProductoBE() {IdProducto="P0006",Nombre="Naproxeno", Precio=0.50, Stock=100 },
                    new ProductoBE() {IdProducto="P0007",Nombre="Panadol Antigripal", Precio=1.50, Stock=200 },
                    new ProductoBE() {IdProducto="P0008",Nombre="Diclofenaco Crema", Precio=10, Stock=50 },
                    new ProductoBE() {IdProducto="P0009",Nombre="Sulfanil Crema", Precio=2.70, Stock=27 },
                    new ProductoBE() {IdProducto="P0010",Nombre="Coramina 10g", Precio=0.30, Stock=14 },
                    new ProductoBE() {IdProducto="P0011",Nombre="Mantequilla de Cacao Barra", Precio=0.10, Stock=19 },
                    new ProductoBE() {IdProducto="P0012",Nombre="Pediasure Advance", Precio=30.50, Stock=15 },
                    new ProductoBE() {IdProducto="P0013",Nombre="Neurobion 4000 Ampoya", Precio=8.50, Stock=25 }/*,
                    new ProductoBE() {IdProducto="P0014",Nombre="", Precio=, Stock= },
                    new ProductoBE() {IdProducto="P0015",Nombre="", Precio=, Stock= },
                    new ProductoBE() {IdProducto="P0016",Nombre="", Precio=, Stock= },
                    new ProductoBE() {IdProducto="P0017",Nombre="", Precio=, Stock= },
                    new ProductoBE() {IdProducto="P0018",Nombre="", Precio=, Stock= },
                    new ProductoBE() {IdProducto="P0019",Nombre="", Precio=, Stock= },
                    new ProductoBE() {IdProducto="P0020",Nombre="", Precio=, Stock= }*/
                };

                List<PedidoBE> pedidos = new List<PedidoBE>()
                {
                    new PedidoBE() { IdPedido="O0001", Estado=2, ClienteID="73524246", FarmaceuticoID="F001" },
                    new PedidoBE() { IdPedido="O0002", Estado=0, ClienteID="79260045", FarmaceuticoID="F001" },
                    new PedidoBE() { IdPedido="O0003", Estado=0, ClienteID="89420362", FarmaceuticoID="F001" },

                    new PedidoBE() { IdPedido="O0004", Estado=2, ClienteID="64213995", FarmaceuticoID="F002" }/*,
                    new PedidoBE() { IdPedido="O0005", Estado=1, ClienteID="", FarmaceuticoID="F002" },
                    new PedidoBE() { IdPedido="O0006", Estado=1, ClienteID="", FarmaceuticoID="F002" },
                    new PedidoBE() { IdPedido="O0007", Estado=1, ClienteID="", FarmaceuticoID="F002" }*/
                };

                List<DetalleVentaBE> detalles = new List<DetalleVentaBE>()
                {
                    new DetalleVentaBE() { NumDetalle=1, Cantidad=4, PedidoID="O0001" , ProductoID="P0001" },
                    new DetalleVentaBE() { NumDetalle=2, Cantidad=2, PedidoID="O0001" , ProductoID="P0002" },

                    new DetalleVentaBE() { NumDetalle=1, Cantidad=1, PedidoID="O0002" , ProductoID="P0011" },
                    new DetalleVentaBE() { NumDetalle=2, Cantidad=4, PedidoID="O0002" , ProductoID="P0013" },

                    new DetalleVentaBE() { NumDetalle=1, Cantidad=1, PedidoID="O0003" , ProductoID="P0008" },
                    new DetalleVentaBE() { NumDetalle=2, Cantidad=1, PedidoID="O0003" , ProductoID="P0012" },
                    new DetalleVentaBE() { NumDetalle=3, Cantidad=10, PedidoID="O0003" , ProductoID="P0004" },
                    new DetalleVentaBE() { NumDetalle=4, Cantidad=1, PedidoID="O0003" , ProductoID="P0009" },

                    new DetalleVentaBE() { NumDetalle=1, Cantidad=2, PedidoID="O0004" , ProductoID="P0010" }
                     
                    //new DetalleVentaBE() { NumDetalle=1, Cantidad=, VentaID="" , ProductoID="" },
                    //new DetalleVentaBE() { NumDetalle=1, Cantidad=, VentaID="" , ProductoID="" },
                };

                List<VentaBE> ventas = new List<VentaBE>()
                {
                    new VentaBE() { IdVenta="V0001", Fecha=DateTime.Parse("31/10/2019"), PedidoID="O0001" },
                    //new VentaBE() { IdVenta="V0002", Fecha= , PedidoID="" },
                    //new VentaBE() { IdVenta="V0003", Fecha= , PedidoID="" },
                    new VentaBE() { IdVenta="V0004", Fecha=DateTime.Parse("08/12/2019"), PedidoID="O0004" },
                    //new VentaBE() { IdVenta="V0005", Fecha= , PedidoID="" }
                };            

                /*context.DbPerfil.AddRange(Perfiles);
                context.DbUsuario.AddRange(Usuarios);*/

                context.DbCliente.AddRange(clientes);
                context.DbFarmaceutico.AddRange(farmaceuticos);
                context.DbProducto.AddRange(productos);
                context.DbPedido.AddRange(pedidos);
                context.DbVenta.AddRange(ventas);
                context.DbDetalleVenta.AddRange(detalles);

                base.InitializeDatabase(context);
                base.Seed(context);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
