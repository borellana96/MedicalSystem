using FarmaciaBE;
using FarmaciaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBL
{
    public class ProductoBL
    {
        public ProductoBE ObtenerProducto(string IdProducto)
        {
            ProductoDA oProductoDA = new ProductoDA();

            try
            {
                ProductoBE ObjProducto = oProductoDA.ObtenerProducto(IdProducto);
                return ObjProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductoBE> ListarProductos()
        {
            ProductoDA oProductoDA = new ProductoDA();

            try
            {
                return oProductoDA.ListarProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oProductoDA = null;
            }
        }

        public bool GuardarProducto(ProductoBE objProducto, out string IdProducto, out string mensaje)
        {
            ProductoDA objProductoDA = new ProductoDA();

            try
            {
                if (objProducto.Nombre=="")
                {
                    IdProducto = "0";
                    mensaje = "El nombre del Producto no puede estar vacio.";
                    return false;
                }
                if (objProductoDA.GuardarProducto(objProducto, out IdProducto))
                {
                    mensaje = "Se registro al Producto.";
                    return true;
                }
                else
                {
                    IdProducto = "0";
                    mensaje = "Ocurrio un error al guardar al Producto.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarProducto(ProductoBE objProducto)
        {
            ProductoDA objProductoDA = new ProductoDA();

            try
            {
                if (objProductoDA.ActualizarProducto(objProducto)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarProducto(string IdProducto)
        {
            ProductoDA objProductoDA = new ProductoDA();

            try
            {
                if (objProductoDA.EliminarProducto(IdProducto)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
