using FarmaciaBE;
using FarmaciaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBL
{
    public class FarmaceuticoBL
    {
        public FarmaceuticoBE ObtenerFarmaceutico(string IdFarmaceutico)
        {
            FarmaceuticoDA oFarmaceuticoDA = new FarmaceuticoDA();

            try
            {
                FarmaceuticoBE ObjFarmaceutico = oFarmaceuticoDA.ObtenerFarmaceutico(IdFarmaceutico);
                return ObjFarmaceutico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FarmaceuticoBE> ListarFarmaceuticos()
        {
            FarmaceuticoDA oFarmaceuticoDA = new FarmaceuticoDA();

            try
            {
                return oFarmaceuticoDA.ListarFarmaceuticos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oFarmaceuticoDA = null;
            }
        }

        public bool GuardarFarmaceutico(FarmaceuticoBE objFarmaceutico, out string IdFarmaceutico, out string mensaje)
        {
            FarmaceuticoDA objFarmaceuticoDA = new FarmaceuticoDA();

            try
            {
                /*if (objFarmaceutico.Nombre == "")
                {
                    IdFarmaceutico = "0";
                    mensaje = "El nombre del Farmaceutico no puede estar vacio.";
                    return false;
                }*/
                if (objFarmaceuticoDA.GuardarFarmaceutico(objFarmaceutico, out IdFarmaceutico))
                {
                    mensaje = "Se registro al Farmaceutico.";
                    return true;
                }
                else
                {
                    IdFarmaceutico = "0";
                    mensaje = "Ocurrio un error al guardar al Farmaceutico.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarFarmaceutico(FarmaceuticoBE objFarmaceutico)
        {
            FarmaceuticoDA objFarmaceuticoDA = new FarmaceuticoDA();

            try
            {
                if (objFarmaceuticoDA.ActualizarFarmaceutico(objFarmaceutico)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarFarmaceutico(string IdFarmaceutico)
        {
            FarmaceuticoDA objFarmaceuticoDA = new FarmaceuticoDA();

            try
            {
                if (objFarmaceuticoDA.EliminarFarmaceutico(IdFarmaceutico)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
