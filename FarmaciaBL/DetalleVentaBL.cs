using FarmaciaBE;
using FarmaciaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBL
{
    public class DetalleVentaBL
    {
        public DetalleVentaBE ObtenerDetalleVenta(int IdDetalleVenta)
        {
            DetalleVentaDA oDetalleVentaDA = new DetalleVentaDA();

            try
            {
                DetalleVentaBE ObjDetalleVenta = oDetalleVentaDA.ObtenerDetalleVenta(IdDetalleVenta);
                return ObjDetalleVenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DetalleVentaBE> ListarDetalleVentas()
        {
            DetalleVentaDA oDetalleVentaDA = new DetalleVentaDA();

            try
            {
                return oDetalleVentaDA.ListarDetalleVentas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDetalleVentaDA = null;
            }
        }

        public bool GuardarDetalleVenta(DetalleVentaBE objDetalleVenta)//(List<DetalleVentaBE> detalles)
        {
            DetalleVentaDA objDetalleVentaDA = new DetalleVentaDA();

            try
            {
                /*if (objDetalleVenta.Nombre == "")
                {
                    IdDetalleVenta = "0";
                    mensaje = "El nombre del DetalleVenta no puede estar vacio.";
                    return false;
                }*/
                if (objDetalleVentaDA.GuardarDetalleVenta(objDetalleVenta)) // objDetalleVentaDA.GuardarDetalleVenta(detalles)
                {
                    //mensaje = "Se registro al DetalleVenta.";
                    return true;
                }
                else
                {
                    //mensaje = "Ocurrio un error al guardar al DetalleVenta.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarDetalleVenta(DetalleVentaBE objDetalleVenta)
        {
            DetalleVentaDA objDetalleVentaDA = new DetalleVentaDA();

            try
            {
                if (objDetalleVentaDA.ActualizarDetalleVenta(objDetalleVenta)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarDetalleVenta(int IdDetalleVenta)
        {
            DetalleVentaDA objDetalleVentaDA = new DetalleVentaDA();

            try
            {
                if (objDetalleVentaDA.EliminarDetalleVenta(IdDetalleVenta)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
