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
    public class ClienteDA
    {
        public ClienteBE ObtenerCliente(string Dni)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    return objContextDA.DbCliente.Find(Dni);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ClienteBE();
            }
        }
        public List<ClienteBE> ListarClientes()
        {
            try
            {
                using (ContextDA objcontextDA = new ContextDA())
                {
                    return objcontextDA.DbCliente.ToList();
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
                return new List<ClienteBE>();
            }
        }
        public bool GuardarCliente(ClienteBE objCliente, out string Dni)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.DbCliente.Add(objCliente);
                    objContextDA.SaveChanges();
                }

                Dni = objCliente.Dni;
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

                Dni = "";
                return false;
            }
        }
        public bool ActualizarCliente(ClienteBE objCliente)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.Entry(objCliente).State = EntityState.Modified;

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
        public bool EliminarCliente(string Dni)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    ClienteBE objCliente = objContextDA.DbCliente.Find(Dni);
                    objContextDA.DbCliente.Remove(objCliente);

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
