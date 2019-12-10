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
    }
}
