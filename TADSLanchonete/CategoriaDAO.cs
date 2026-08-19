using System;
using System.Collections.Generic;
using System.Linq;

namespace TADSLanchonete
{
    internal class CategoriaDAO
    {
        internal static string Cadastrar(Categoria categoria)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    ctx.Categorias.Add(categoria);
                    ctx.SaveChanges();
                    mensagem = "A categoria " + categoria.NomeCategoria + " foi cadastrada com sucesso!";
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
                    Categoria categoria = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);

                    if (categoria != null)
                    {
                        ctx.Categorias.Remove(categoria);
                        ctx.SaveChanges();
                        mensagem = "A categoria " + categoria.NomeCategoria + " foi removida com sucesso!";
                    }
                    else
                    {
                        mensagem = "Categoria não encontrada.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static List<Categoria> Listar()
        {
            List<Categoria> lista = null;

            try
            {
                using (var ctx = new LanchoneteDBEntities())
                {
                    lista = ctx.Categorias.OrderBy(x => x.NomeCategoria).ToList();
                }
            }
            catch (Exception ex)
            {
                
            }

            return lista;
        }
    }
}