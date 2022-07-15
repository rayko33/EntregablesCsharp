<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MostrarMedidores.aspx.cs" Inherits="LecturaWEB.MostrarMedidores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

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
              
                        </asp:DropDownList>
                    </div>
             
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                    <asp:GridView CssClass="table table-hover table-bordered mt-2" 
                        EmptyDataText="No hay medidores Registrados" ShowHeader="true"
                        OnRowCommand="grillaMedidores_RowCommand"
                        AutoGenerateColumns="false" runat="server" ID="grillaMedidores">
                        <Columns>
                            <asp:BoundField DataField="IdMedidor" HeaderText="ID Medidor" />
                            <asp:BoundField DataField="TipoMedidor.Nombre" HeaderText="Tipo Medidor" />
                            
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
                
                 </ContentTemplate>
               </asp:UpdatePanel>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
