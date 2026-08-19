<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TADSLanchonete.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>TADS Lanchonete - Início</title>
    <!-- Bootstrap CSS CDN -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
</head>
<body class="d-flex flex-column min-vh-100">

    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark mb-4">
            <div class="container">
                <a class="navbar-brand" href="Default.aspx">🍔 TADS Lanchonete</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="Default.aspx">Início</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="frmGerenciarIngredientes.aspx">Ingredientes</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="frmGerenciarCategorias.aspx">Categorias</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <!-- Usando a classe 'container' e flex-grow-1 para empurrar o footer para o final caso a página seja curta -->
    <main class="container flex-grow-1">
        <div class="text-center mt-5">
            <h1>Bem-vindo ao sistema da Lanchonete!</h1>
            <p class="lead">Use o menu superior para navegar e gerenciar seu sistema.</p>
        </div>
    </main>

    <footer class="bg-dark text-white text-center py-3 mt-5 mt-auto">
        <div class="container">
            <p class="mb-0">&copy; 2026 TADS Lanchonete - @pedrinfal.</p>
        </div>
    </footer>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>