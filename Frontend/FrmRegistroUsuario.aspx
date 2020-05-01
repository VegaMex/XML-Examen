<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRegistroUsuario.aspx.cs" Inherits="Frontend.FrmRegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container px-3 py-3 mb-2">
        <h1 class="display-4 text-center">Registro de usuarios</h1>
        <form id="form2" runat="server" novalidate>
            <div id="serverError" class="alert alert-danger" runat="server">
                Se ha producido un error en el servidor
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" TextMode="SingleLine" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El nombre es obligatorio y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtPaterno">Apellido paterno</label>
                    <asp:TextBox ID="txtPaterno" TextMode="SingleLine" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El apellido paterno es obligatorio y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtMaterno">Apellido materno</label>
                    <asp:TextBox ID="txtMaterno" TextMode="SingleLine" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El apellido materno debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtCorreo">Correo electrónico</label>
                    <asp:TextBox ID="txtCorreo" TextMode="Email" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        El correo electrónico es obligatorio y debe tener un formato válido
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtContra">Contraseña</label>
                    <asp:TextBox ID="txtContra" TextMode="Password" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        La contraseña es obligatoria y debe tener al menos 8 caracteres de longitud e incluir mayúsculas, minúsculas y al menos un carácter especial (!@#$%^&*)
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <label for="txtContraConfirm">Confirmar contraseña</label>
                    <asp:TextBox ID="txtContraConfirm" TextMode="Password" class="form-control" autocomplete="off" runat="server" required></asp:TextBox>
                    <div class="invalid-feedback">
                        La verificación de contraseña es obligatoria y deben coincidir
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <asp:Label ID="lblCarrera" AssociatedControlID="ddlCarrera" runat="server" Text="Carrera"></asp:Label>
                    <asp:DropDownList ID="ddlCarrera" class="form-control" runat="server" required></asp:DropDownList>
                    <div class="invalid-feedback">
                        Debe seleccionar una carrera
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <div class="col-md-4 mb-3">
                    <asp:Label ID="lblTipo" AssociatedControlID="ddlTipo" runat="server" Text="Tipo"></asp:Label>
                    <asp:DropDownList ID="ddlTipo" class="form-control" runat="server" required>
                        <asp:ListItem Selected="True" Value="Coordinador">Coordinador</asp:ListItem>
                        <asp:ListItem Value="Encargado">Encargado</asp:ListItem>
                        <asp:ListItem Value="Docente">Docente</asp:ListItem>
                    </asp:DropDownList>
                    <div class="invalid-feedback">
                        Debe seleccionar un tipo
                    </div>
                </div>
            </div>
            <div class="form-row justify-content-center">
                <asp:Button ID="btnCancelar" class="btn btn-secondary mr-4" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnRegistrar" class="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="js/frmRegistroUsuario.js"></script>
</asp:Content>
