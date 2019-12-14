using FarmaciaBE;
using FarmaciaBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MedycalSystem
{
    /// <summary>
    /// Descripción breve de wsFarmacia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsFarmacia : System.Web.Services.WebService
    {

        [WebMethod]
        public ProductoBE ObtenerProducto(string id)
        {
            ProductoBL objProductoBL = new ProductoBL();

            return objProductoBL.ObtenerProducto(id);
        }

        [WebMethod]
        public List<ProductoBE> ListarProductos()
        {
            ProductoBL objProductoBL = new ProductoBL();
            List<ProductoBE> lista = objProductoBL.ListarProductos();
            return lista;
        }

        [WebMethod]
        public bool GuardarPedido(DetalleVentaBE objDetalle)//List<DetalleVentaBE> listaDetalles
        {           
            PedidoBE objPedidoBE = new PedidoBE() { IdPedido = objDetalle.PedidoID, Estado=0 , ClienteID="73524246", FarmaceuticoID="F001" };
            //PedidoBE objPedidoBE = new PedidoBE() { IdPedido = listaDetalles[0].PedidoID, Estado=0 , ClienteID="73524246", FarmaceuticoID="F001" };
      
            PedidoBL objPedidoBL = new PedidoBL();

            //================================================

            DetalleVentaBE objDetalleBE = objDetalle;
            objDetalleBE.NumDetalle = 1;
            /*List<DetalleVentaBE> listaActualizada = new List<DetalleVentaBE>();
            for (int i=0; i<listaDetalles.Count; i++){
                DetalleVentaBE objIterable = new DetalleVentaBE();
                DetalleVentaBE objIterable = listaDetalles[i];
                objIterable.NumDetalle = (i+1);
                //objIterable.Cantidad= listaDetalles[i].Cantidad;
                //objIterable.PedidoID= listaDetalles[i].PedidoID;
                //objIterable.ProductoID= listaDetalles[i].ProductoID;
                listaActualizada.Add(objIterable);
            }*/

            DetalleVentaBL objDetalleBL = new DetalleVentaBL();

            //====================================================

            if (objPedidoBL.GuardarPedido(objPedidoBE) && objDetalleBL.GuardarDetalleVenta(objDetalleBE))
                return true;
            else
                return false;

            /*if (objPedidoBL.GuardarPedido(objPedidoBE) && objDetalleBL.GuardarDetalleVenta(listaActualizada))
                return true;
            else
                return false;*/
        }

        [WebMethod]
        public List<Muestra> ListarPedidos()
        {
            PedidoBL objPedidoBL = new PedidoBL();
            ClienteBL objClienteBL = new ClienteBL();

            List<PedidoBE> listaPedidos = objPedidoBL.ListarPedidos();
            List<ClienteBE> listaClientes = objClienteBL.ListarClientes();

            List<Muestra> listaTabla = new List<Muestra>();

            for (int i = 0; i < listaPedidos.Count; i++)
            {
                var m = new Muestra {
                    dni = listaClientes[i].Dni,
                    apellidop = listaClientes[i].ApellidoP,
                    apellidom = listaClientes[i].ApellidoM,
                    estado = listaPedidos[i].Estado
                };
                listaTabla.Add(m);
            }

            return listaTabla;
        }
    }
}
