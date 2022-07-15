<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="LecturaWEB.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-4 mx-auto">
            <div class="mensaje">
                <asp:Label runat="server" ID="mensajeLbl" CssClass="text-success"></asp:Label>
            </div>
            <div class="card">
                <div class="card-header bg-light text-dark">
                    <h3>Agregar Usuario - (Sitio En contruaccion)</h3>
                    <image class="rounded float-end"src="src/herramienta-de-construccion.png"></image>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="NombreTxt">Nombre usuario</label>
                        <asp:TextBox ID="NombreTxt" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NombreValidador" runat="server"
                            ControlToValidate="NombreTxt" ErrorMessage="Se requiere su nombre y apellido" ></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                        <label for="rutTxt">Rut usuario</label>
                        <asp:TextBox ID="rutTxt" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rutValidator" runat="server"
                            ControlToValidate="rutTxt" ErrorMessage="Se requiere un rut" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="correotTxt">Correo usuario</label>
                        <asp:TextBox ID="correoTxt" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="correodValidator" runat="server"
                            ControlToValidate="correoTxt" ErrorMessage="Se requiere un correo" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="passoTxt">Password usuario</label>
                        <asp:TextBox ID="passTxt" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="passValidator" runat="server"
                            ControlToValidate="passTxt" ErrorMessage="Se requiere una password" ></asp:RequiredFieldValidator>
                    </div>                  
                    <div class="form-group mt-3">
                        <asp:Button runat="server" ID="agregarBtn" 
                            Text="Agregar Usuario" CssClass="btn btn-primary" OnClick="agregarBtn_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
