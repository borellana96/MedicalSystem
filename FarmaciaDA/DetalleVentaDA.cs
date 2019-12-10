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
    public class DetalleVentaDA
    {
        public DetalleVentaBE ObtenerDetalleVenta(int NumDetalle)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    return objContextDA.DbDetalleVenta.Find(NumDetalle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DetalleVentaBE();
            }
        }
        public List<DetalleVentaBE> ListarDetalleVentas()
        {
            try
            {
                using (ContextDA objcontextDA = new ContextDA())
                {
                    return objcontextDA.DbDetalleVenta.ToList();
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
                return new List<DetalleVentaBE>();
            }
        }
        public bool GuardarDetalleVenta(DetalleVentaBE objDetalleVenta, out int NumDetalle)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.DbDetalleVenta.Add(objDetalleVenta);
                    objContextDA.SaveChanges();
                }

                NumDetalle = objDetalleVenta.NumDetalle;
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

                NumDetalle = 0;
                return false;
            }
        }
        public bool ActualizarDetalleVenta(DetalleVentaBE objDetalleVenta)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.Entry(objDetalleVenta).State = EntityState.Modified;

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
        public bool EliminarDetalleVenta(int NumDetalle)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    DetalleVentaBE objDetalleVenta = objContextDA.DbDetalleVenta.Find(NumDetalle);
                    objContextDA.DbDetalleVenta.Remove(objDetalleVenta);

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
