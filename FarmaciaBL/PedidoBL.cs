using FarmaciaBE;
using FarmaciaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBL
{
    public class PedidoBL
    {
        public PedidoBE ObtenerPedido(string IdPedido)
        {
            PedidoDA oPedidoDA = new PedidoDA();

            try
            {
                PedidoBE ObjPedido = oPedidoDA.ObtenerPedido(IdPedido);
                return ObjPedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoBE> ListarPedidos()
        {
            PedidoDA oPedidoDA = new PedidoDA();

            try
            {
                return oPedidoDA.ListarPedidos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oPedidoDA = null;
            }
        }

        public bool GuardarPedido(PedidoBE objPedido, out string IdPedido, out string mensaje)
        {
            PedidoDA objPedidoDA = new PedidoDA();

            try
            {
                /*if (objPedido.Nombre == "")
                {
                    IdPedido = "0";
                    mensaje = "El nombre del Pedido no puede estar vacio.";
                    return false;
                }*/
                if (objPedidoDA.GuardarPedido(objPedido, out IdPedido))
                {
                    mensaje = "Se registro al Pedido.";
                    return true;
                }
                else
                {
                    IdPedido = "0";
                    mensaje = "Ocurrio un error al guardar al Pedido.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarPedido(PedidoBE objPedido)
        {
            PedidoDA objPedidoDA = new PedidoDA();

            try
            {
                if (objPedidoDA.ActualizarPedido(objPedido)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarPedido(string IdPedido)
        {
            PedidoDA objPedidoDA = new PedidoDA();

            try
            {
                if (objPedidoDA.EliminarPedido(IdPedido)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
