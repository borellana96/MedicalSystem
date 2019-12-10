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
    public class FarmaceuticoDA
    {
        public FarmaceuticoBE ObtenerFarmaceutico(string IdFarmaceutico)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    return objContextDA.DbFarmaceutico.Find(IdFarmaceutico);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new FarmaceuticoBE();
            }
        }
        public List<FarmaceuticoBE> ListarFarmaceuticos()
        {
            try
            {
                using (ContextDA objcontextDA = new ContextDA())
                {
                    return objcontextDA.DbFarmaceutico.ToList();
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return new List<FarmaceuticoBE>();
            }
        }
        public bool GuardarFarmaceutico(FarmaceuticoBE objFarmaceutico, out string IdFarmaceutico)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.DbFarmaceutico.Add(objFarmaceutico);
                    objContextDA.SaveChanges();
                }

                IdFarmaceutico = objFarmaceutico.IdFarmaceutico;
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }

                IdFarmaceutico = "";
                return false;
            }
        }
        public bool ActualizarFarmaceutico(FarmaceuticoBE objFarmaceutico)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.Entry(objFarmaceutico).State = EntityState.Modified;

                    objContextDA.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
        }
        public bool EliminarFarmaceutico(string IdFarmaceutico)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    FarmaceuticoBE objFarmaceutico = objContextDA.DbFarmaceutico.Find(IdFarmaceutico);
                    objContextDA.DbFarmaceutico.Remove(objFarmaceutico);

                    objContextDA.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
        }
    }
}
