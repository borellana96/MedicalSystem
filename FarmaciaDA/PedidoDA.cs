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
    public class PedidoDA
    {
        public PedidoBE ObtenerPedido(string IdPedido)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    return objContextDA.DbPedido.Find(IdPedido);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new PedidoBE();
            }
        }
        public List<PedidoBE> ListarPedidos()
        {
            try
            {
                using (ContextDA objcontextDA = new ContextDA())
                {
                    return objcontextDA.DbPedido.ToList();
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
                return new List<PedidoBE>();
            }
        }
        public bool GuardarPedido(PedidoBE objPedido)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.DbPedido.Add(objPedido);
                    objContextDA.SaveChanges();
                }

                //IdPedido = objPedido.IdPedido;
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

                //IdPedido = "";
                return false;
            }
        }
        public bool ActualizarPedido(PedidoBE objPedido)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    objContextDA.Entry(objPedido).State = EntityState.Modified;

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
        public bool EliminarPedido(string IdPedido)
        {
            try
            {
                using (ContextDA objContextDA = new ContextDA())
                {
                    PedidoBE objPedido = objContextDA.DbPedido.Find(IdPedido);
                    objContextDA.DbPedido.Remove(objPedido);

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
