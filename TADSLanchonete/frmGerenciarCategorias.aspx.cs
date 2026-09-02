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
            LvCategorias.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomecategoria = txtNomeCategoria.Value;
                bool editando = false;

                if (string.IsNullOrEmpty(nomecategoria))
                {
                    Mensagem.InnerText = "O campo Nome Categoria precisa ser preenchido!";
                    return;
                }

                Categoria categoria = null;

                if (ViewState["IdCategoria"] == null)
                {
                    categoria = new Categoria();
                }
                else
                {
                    int idCategoria = (int)ViewState["IdCategoria"];
                    categoria = CategoriaDAO.Listar(idCategoria);
                    editando = true;
                }

                categoria.NomeCategoria = nomecategoria;

                if (!editando)
                {
                    Mensagem.InnerText = CategoriaDAO.Cadastrar(categoria);
                }
                else
                {
                    Mensagem.InnerText = CategoriaDAO.Editar(categoria);
                    btnConfirmar.Text = "Cadastrar";
                    ViewState["IdCategoria"] = null;
                }

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
                    else if (e.CommandName == "Visualizar")
                    {
                        Categoria categoria = CategoriaDAO.Listar(id);

                        bool visualizar = true;
                        ModificarFormularioParaVisualizar(categoria, visualizar);

                        string mensagem = CategoriaDAO.Visualizar(id);
                        Mensagem.InnerText = mensagem;
                        AtualizarListView();
                    }
                    else if (e.CommandName == "Editar")
                    {
                        Categoria categoria = CategoriaDAO.Listar(id);

                        bool visualizar = false;
                        ModificarFormularioParaVisualizar(categoria, visualizar);

                        EditarFormulario(categoria);

                        Mensagem.InnerText = "Edite o nome da categoria e clique em Editar.";
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocorreu um erro ao excluir: " + ex.Message;
            }
        }

        private void EditarFormulario(Categoria categoria)
        {
            btnConfirmar.Text = "Editar";
            ViewState["IdCategoria"] = categoria.IdCategoria;
        }

        private void ModificarFormularioParaVisualizar(Categoria categoria, bool visualizar)
        {
            if (visualizar)
            {
                txtNomeCategoria.Disabled = true;
                btnConfirmar.Visible = false;
                btnLinkCadastrar.Visible = true;
            }

            txtNomeCategoria.Value = categoria.NomeCategoria;
        }
    }
}