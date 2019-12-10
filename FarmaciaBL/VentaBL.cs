using FarmaciaBE;
using FarmaciaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBL
{
    public class VentaBL
    {
        public VentaBE ObtenerVenta(string IdVenta)
        {
            VentaDA oVentaDA = new VentaDA();

            try
            {
                VentaBE ObjVenta = oVentaDA.ObtenerVenta(IdVenta);
                return ObjVenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VentaBE> ListarVentas()
        {
            VentaDA oVentaDA = new VentaDA();

            try
            {
                return oVentaDA.ListarVentas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oVentaDA = null;
            }
        }

        public bool GuardarVenta(VentaBE objVenta, out string IdVenta, out string mensaje)
        {
            VentaDA objVentaDA = new VentaDA();

            try
            {
                /*if (objVenta.Nombre == "")
                {
                    IdVenta = "0";
                    mensaje = "El nombre del Venta no puede estar vacio.";
                    return false;
                }*/
                if (objVentaDA.GuardarVenta(objVenta, out IdVenta))
                {
                    mensaje = "Se registro al Venta.";
                    return true;
                }
                else
                {
                    IdVenta = "0";
                    mensaje = "Ocurrio un error al guardar al Venta.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarVenta(VentaBE objVenta)
        {
            VentaDA objVentaDA = new VentaDA();

            try
            {
                if (objVentaDA.ActualizarVenta(objVenta)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarVenta(string IdVenta)
        {
            VentaDA objVentaDA = new VentaDA();

            try
            {
                if (objVentaDA.EliminarVenta(IdVenta)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
