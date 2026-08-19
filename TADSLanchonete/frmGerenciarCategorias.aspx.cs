using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TADSLanchonete
{
    public partial class frmGerenciarCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarListView();
            }
        }

        private void AtualizarListView()
        {
            List<Categoria> categorias = CategoriaDAO.Listar();
            PopularLvCategoria(categorias);
        }

        private void PopularLvCategoria(List<Categoria> categorias)
        {
            if (categorias == null)
            {
                return;
            }

            LvCategorias.DataSource = categorias;
            LvCategorias.DataBind(); //Renderiza os elementos da tela.
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomecategoria = txtNomeCategoria.Value;
                if (string.IsNullOrEmpty(nomecategoria))
                {
                    Mensagem.InnerText = "O campo Nome Categoria precisa ser preenchido!";
                    return;
                }

                var categoria = new Categoria();
                categoria.NomeCategoria = nomecategoria;

                Mensagem.InnerText = CategoriaDAO.Cadastrar(categoria);

                txtNomeCategoria.Value = "";

                AtualizarListView();
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocorreu um erro: " + ex.Message;
            }
        }

        protected void LvCategorias_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int id))
                {
                    if (e.CommandName == "Excluir")
                    {
                        string mensagem = CategoriaDAO.Excluir(id);
                        Mensagem.InnerText = mensagem;
                        AtualizarListView();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocorreu um erro ao excluir: " + ex.Message;
            }
        }
    }
}