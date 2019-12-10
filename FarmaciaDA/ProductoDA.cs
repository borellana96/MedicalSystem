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
    public class ProductoDA
    {
        public ProductoBE ObtenerProducto(string IdProducto)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    return objContextDA.DbProducto.Find(IdProducto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ProductoBE();
            }
        }
        public List<ProductoBE> ListarProductos()
        {
            try
            {
                using (ContextDA objcontextDA = new ContextDA())
                {
                    return objcontextDA.DbProducto.ToList();
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
                return new List<ProductoBE>();
            }          
        }
        public bool GuardarProducto(ProductoBE objProducto, out string IdProducto)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.DbProducto.Add(objProducto);
                    objContextDA.SaveChanges();
                }

                IdProducto = objProducto.IdProducto;
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

                IdProducto = "";
                return false;
            }
        }
        public bool ActualizarProducto(ProductoBE objProducto)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.Entry(objProducto).State = EntityState.Modified;

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
        public bool EliminarProducto(string IdProducto)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    ProductoBE objProducto = objContextDA.DbProducto.Find(IdProducto);
                    objContextDA.DbProducto.Remove(objProducto);

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
