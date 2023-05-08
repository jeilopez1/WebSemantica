<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.View.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Proyecto final</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl"
        crossorigin="anonymous">

    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.15/css/jquery.dataTables.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0"
        crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.15/js/jquery.dataTables.js"></script>

</head>
<body>
    <div class="container h-100">
        <h1 class="text-center">Centro de Salud </h1>
        <div class="row justify-content-center h-100">
            <div class="col-sm-10 align-self-center text-center">
                <div class="card shadow">
                    <div class="card-body">

                        <div>
                            <h1 class="text-center"></h1>
                        </div>



                        <form id="form1" runat="server">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ColorList" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ColorList_SelectedIndexChanged">

                                            <asp:ListItem Selected="True" Value="nada"> Seleccione </asp:ListItem>
                                            <asp:ListItem Value="BMedico"> todos los Medicos </asp:ListItem>
                                            <asp:ListItem Value="BPaciente"> Todos los Pacientes </asp:ListItem>
                                            <asp:ListItem Value="BIPS"> Todos las IPS </asp:ListItem>
                                            <asp:ListItem Value="Enfermedad"> Enfermedad </asp:ListItem>
                                            <asp:ListItem Value="Paciente"> Buscar Paciente </asp:ListItem>
                                            <asp:ListItem Value="IPS"> IPS </asp:ListItem>
                                            <asp:ListItem Value="Medicamento"> Medicamento </asp:ListItem>

                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-9">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" placeholder="Nombre paciente" ID="search" CssClass="form-control"
                                                required="required"></asp:TextBox>
                                        </div>
                                         <table class="table table-bordered table-striped" id="tabla555">
                                            <asp:ListView runat="server" ID="ListaPacientes">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("paciente")%></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                                             <asp:ListView runat="server" ID="ListaMedico">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("medico")%></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                                             <asp:ListView runat="server" ID="ListaIPS">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("ips")%></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </table>
                                    </div>
                                </div>
                                <div class="container">
                                    <div class="d-grid gap-2 d-md-block">
                                        <asp:Button Class="btn btn-primary" runat="server" Text="Buscar" OnClick="searchOntology" ID="Button2" />
                                    </div>
                                </div>
                            </div>
                        </form>


                        <br />
                        <div class="text-center">
                            <div class="card-body table-responsive p-0">
                                <table class="table table-bordered table-striped" id="table1">

                                    <tbody>
                                        <asp:ListView runat="server" ID="ListViewResult">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("s")%></td>
                                                    <td><%#Eval("o")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                        <asp:ListView runat="server" ID="ListView1">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("paciente")%></td>
                                                    <td><%#Eval("medicamento")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                        <asp:ListView runat="server" ID="enfermedadMedicamentoMedico">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("enfermedad")%></td>
                                                    <td><%#Eval("medicamento")%></td>
                                                    <td><%#Eval("medico")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                        <asp:ListView runat="server" ID="ips">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("paciente")%></td>
                                                    <td><%#Eval("medico")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                        <asp:ListView runat="server" ID="InfoPaciente">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("enfermedad")%></td>
                                                    <td><%#Eval("paciente")%></td>
                                                    <td><%#Eval("pesopaciente")%></td>
                                                    <td><%#Eval("numdocumento")%></td>
                                                    <td><%#Eval("nomsintoma ")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--     <script>
<%--        $(document).ready(function () {
            $('#table1').DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
                },
            });
        });
    </script>--%>
</body>
</html>
