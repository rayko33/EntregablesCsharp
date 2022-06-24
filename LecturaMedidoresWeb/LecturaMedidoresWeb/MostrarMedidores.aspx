<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MostrarMedidores.aspx.cs" Inherits="LecturaMedidoresWeb.MostrarMedidores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6 mx-auto">
            <div class="card">
                <div class="card-header bg-danger text-white">
                    <h3>Ver Medidor</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="tipoMedidor">Filtrar por tipo de medidor</label>
                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="tipoMedidor_SelectedIndexChanged" runat="server" ID="tipoMedidor">
                            <asp:ListItem  value="1" Text="Smart"></asp:ListItem>
                            <asp:ListItem  value="2" Text="Convencional"></asp:ListItem>
                            
                        </asp:DropDownList>
                    </div>
                    <asp:GridView CssClass="table table-hover table-bordered mt-2" 
                        EmptyDataText="No hay Clientes" ShowHeader="true"
                        
                        AutoGenerateColumns="false" runat="server" ID="grillaMedidores">
                        <Columns>
                            <asp:BoundField DataField="IdMedidor" HeaderText="ID Medidor" />
                            <asp:BoundField DataField="TextoTipo" HeaderText="Tipo Medidor" />
                            
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button 
                                    CommandName="eliminar"
                                    CommandArgument='<%# Eval("IdMedidor") %>'
                                    runat="server" 
                                    CssClass="btn btn-danger" Text="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
</asp:Content>
