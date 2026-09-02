<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGerenciarCategorias.aspx.cs" Inherits="TADSLanchonete.frmGerenciarCategorias" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Gerenciar Categorias - TADS Lanchonete</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
</head>
<body class="d-flex flex-column min-vh-100">

    <!-- HEADER / MENU -->
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark mb-4">
            <div class="container">
                <a class="navbar-brand" href="Default.aspx">🍔 TADS Lanchonete</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item"><a class="nav-link" href="Default.aspx">Início</a></li>
                        <li class="nav-item"><a class="nav-link" href="frmGerenciarIngredientes.aspx">Ingredientes</a></li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="frmGerenciarCategorias.aspx">Categorias</a></li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <!-- CONTEÚDO PRINCIPAL -->
    <main class="container flex-grow-1">
        <div class="row">
            <div class="col-md-8 offset-md-2">
                <h2 class="mb-4 border-bottom pb-2">Cadastrar Categoria</h2>

                <form id="form1" runat="server" class="card p-4 shadow-sm mb-5">
                    <div class="mb-3">
                        <label for="txtNomeCategoria" class="form-label">Nome da Categoria</label>
                        <input type="text" id="txtNomeCategoria" runat="server" class="form-control" placeholder="Ex: Bebidas, Lanches..." />
                    </div>

                    <div class="mb-3">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Cadastrar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
                    </div>

                    <div class="mb-3">
                        <a href="frmGerenciarCategorias.aspx" id="btnLinkCadastrar" runat="server" class="btn btn-primary" visible="false">Ir para Cadastrar Categorias</a>
                    </div>

                    <!-- Mensagem de Retorno -->
                    <p id="Mensagem" runat="server" class="text-danger fw-bold"></p>

                    <hr class="my-4" />

                    <h3 class="h5 mb-3">Categorias Cadastradas</h3>

                    <div class="table-responsive">
                        <table class="table table-striped table-hover table-bordered align-middle">
                            <thead class="table-dark">
                                <tr>
                                    <th>Código</th>
                                    <th>Descrição</th>
                                    <th class="text-center">Ações</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView runat="server" ID="LvCategorias" OnItemCommand="LvCategorias_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("IdCategoria") %></td>
                                            <td><%# Eval("NomeCategoria") %></td>
                                            <td class="text-center">
                                                <asp:Button runat="server" ID="btnVisualizar" CommandName="Visualizar" CommandArgument='<%# Eval("IdCategoria") %>' CssClass="btn btn-sm btn-outline-secondary" Text="Visualizar" />
                                                <asp:Button runat="server" ID="btnEditar" CommandName="Editar" CommandArgument='<%# Eval("IdCategoria") %>' CssClass="btn btn-sm btn-outline-warning" Text="Editar" />
                                                <asp:Button runat="server" ID="btnExcluir" CommandName="Excluir" CommandArgument='<%# Eval("IdCategoria") %>' CssClass="btn btn-sm btn-outline-danger" Text="Excluir" OnClientClick="return confirm('Deseja realmente excluir essa categoria ?')"/>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>

                </form>

            </div>
        </div>
    </main>

    <!-- FOOTER -->
    <footer class="bg-dark text-white text-center py-3 mt-auto">
        <div class="container">
            <p class="mb-0">&copy; 2026 TADS Lanchonete - @pedrin_fal</p>
        </div>
    </footer>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>