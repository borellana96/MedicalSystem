using FarmaciaBE;
using FarmaciaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBL
{
    public class ClienteBL
    {
        public ClienteBE ObtenerCliente(string IdCliente)
        {
            ClienteDA oClienteDA = new ClienteDA();

            try
            {
                ClienteBE ObjCliente = oClienteDA.ObtenerCliente(IdCliente);
                return ObjCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteBE> ListarClientes()
        {
            ClienteDA oClienteDA = new ClienteDA();

            try
            {
                return oClienteDA.ListarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oClienteDA = null;
            }
        }

        public bool GuardarCliente(ClienteBE objCliente, out string IdCliente, out string mensaje)
        {
            ClienteDA objClienteDA = new ClienteDA();

            try
            {
                /*if (objCliente.Nombre == "")
                {
                    IdCliente = "0";
                    mensaje = "El nombre del Cliente no puede estar vacio.";
                    return false;
                }*/
                if (objClienteDA.GuardarCliente(objCliente, out IdCliente))
                {
                    mensaje = "Se registro al Cliente.";
                    return true;
                }
                else
                {
                    IdCliente = "0";
                    mensaje = "Ocurrio un error al guardar al Cliente.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarCliente(ClienteBE objCliente)
        {
            ClienteDA objClienteDA = new ClienteDA();

            try
            {
                if (objClienteDA.ActualizarCliente(objCliente)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarCliente(string IdCliente)
        {
            ClienteDA objClienteDA = new ClienteDA();

            try
            {
                if (objClienteDA.EliminarCliente(IdCliente)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
