<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LecturaMedidoresWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-lg-4 mx-auto">
            <div class="mensaje">
                <asp:Label runat="server" ID="mensajeLbl" CssClass="text-success"></asp:Label>
            </div>
            <div class="card">
                <div class="card-header bg-dark text-white">
                    <h3>Agregar Medidor</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="IDTxt">ID Medidor</label>
                        <asp:TextBox ID="IDTxt" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="idMedidorValidador" runat="server"
                            ControlToValidate="IDTxt" ErrorMessage="Se requiere un ID" ></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                        <label for="tipo">Tipo Medidor</label>
                        <asp:DropDownList runat="server" ID="tipo" CssClass="form-select">
                            <ASP:ListItem Selected="True" Value="0" text="Seleccione un tipo"></ASP:ListItem>
                            <ASP:ListItem  Value="1" text="Smart"></ASP:ListItem>
                            <ASP:ListItem  Value="2" text="Convencional"></ASP:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tipoMedidor" runat="server"
                            ControlToValidate="tipo" ErrorMessage="Se requiere seleccionar un tipo" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                   
                    <div class="form-group">
                        <asp:Button runat="server" ID="agregarBtn" 
                            Text="Agregar" CssClass="btn btn-primary" OnClick="agregarBtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

