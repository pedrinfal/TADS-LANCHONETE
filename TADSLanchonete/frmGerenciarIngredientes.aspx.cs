using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TADSLanchonete
{
    public partial class frmGerenciarIngredientes : System.Web.UI.Page
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
            List<Ingrediente> ingredientes = IngredienteDAO.Listar();
            PopularLvIngredientes(ingredientes);
        }

        private void PopularLvIngredientes(List<Ingrediente> ingredientes)
        {
            if (ingredientes == null)
            {
                return;
            }

            LvIngredientes.DataSource = ingredientes;
            LvIngredientes.DataBind(); //Renderiza os elementos da tela.
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeingrediente = txtNomeIngrediente.Value;
                if (string.IsNullOrEmpty(nomeingrediente))
                {
                    Mensagem.InnerText = "O campo Nome Ingrediente precisa ser preenchido!";
                    return;
                }

                var ingrediente = new Ingrediente();
                ingrediente.NomeIngrediente = nomeingrediente;

                Mensagem.InnerText = IngredienteDAO.Cadastrar(ingrediente);

                txtNomeIngrediente.Value = "";

                AtualizarListView();
            }
            catch (Exception ex)
            {
                Mensagem.InnerText = "Ocorreu um erro: " + ex.Message;
            }
        }

        protected void LvIngredientes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int id))
                {
                    if (e.CommandName == "Excluir")
                    {
                        string mensagem = IngredienteDAO.Excluir(id);
                        Mensagem.InnerText = mensagem;
                        AtualizarListView();
                    }
                    else if (e.CommandName == "Visualizar")
                    {
                        Ingrediente ingrediente = IngredienteDAO.Listar(id);
                        ModificarFormularioParaVisualizar(ingrediente);




                        string mensagem = IngredienteDAO.Visualizar(id);
                        Mensagem.InnerText = mensagem;
                        AtualizarListView();
                    }

                    if (e.CommandName == "Editar")
                    {
                        string mensagem = IngredienteDAO.Editar(id);
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

        private void ModificarFormularioParaVisualizar(Ingrediente ingrediente)
        {
            txtNomeIngrediente.Disabled = true;
            btnConfirmar.Visible = false;
            btnLinkCadastrar.Visible = true;
            txtNomeIngrediente.Value = ingrediente.NomeIngrediente;
        }
    }
}