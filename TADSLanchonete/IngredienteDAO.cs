using System;
using System.Collections.Generic;
using System.Linq;

namespace TADSLanchonete
{
    internal class IngredienteDAO
    {
        internal static string Cadastrar(Ingrediente ingrediente)
        {
            string mensagem = "";

            try
            {
                using(var ctx = new LanchoneteDBEntities())
                {
                    ctx.Ingredientes.Add(ingrediente);
                    ctx.SaveChanges();
                    mensagem = "O ingrediente " + ingrediente.NomeIngrediente + " foi cadastrado com sucesso!";
                }
            }
            catch (Exception ex) 
            { 
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static string Editar(int id)
        {
            string mensagem = "";
             try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    Ingrediente ingrediente = ctx.Ingredientes.FirstOrDefault(x => x.IdIngrediente == id);
                    ctx.Ingredientes.Remove(ingrediente);
                    ctx.SaveChanges();

                    mensagem = "O ingrediente " + ingrediente.NomeIngrediente + " foi alterado com sucesso!";
                }
            }
            catch (Exception ex) 
            { 
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static string Excluir(int id)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    Ingrediente ingrediente = ctx.Ingredientes.FirstOrDefault(x => x.IdIngrediente == id);
                    ctx.Ingredientes.Remove(ingrediente);
                    ctx.SaveChanges();

                    mensagem = "O ingrediente " + ingrediente.NomeIngrediente + " foi removido com sucesso!";
                }
            }
            catch (Exception ex) 
            { 
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static List<Ingrediente> Listar()
        {
            List<Ingrediente> lista = null;

            try
            {
                using(var ctx = new LanchoneteDBEntities())
                {
                    lista = ctx.Ingredientes.OrderBy(x => x.NomeIngrediente).ToList();
                }
            }
            catch (Exception ex) 
            { 
            
            }
            return lista;
        }

        internal static string Visualizar(int id)
        {
            string mensagem = "";
            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    Ingrediente ingrediente = ctx.Ingredientes.FirstOrDefault(x => x.IdIngrediente == id);

                    mensagem = "INGREDIENTE: " + ingrediente.NomeIngrediente + " !";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }
    }
}