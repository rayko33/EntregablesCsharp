<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MostrarLectura.aspx.cs" Inherits="LecturaMedidoresWeb.MostrarLectura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-6 mx-auto">
            <div class="card">
                <div class="card-header bg-danger text-white">
                    <h3>Ver Lecturas</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="Medidores">Filtrar medidor</label>
                        <asp:DropDownList AutoPostBack="true" runat="server" ID="Medidores" OnSelectedIndexChanged="Medidores_SelectedIndexChanged">
                            
                            
                        </asp:DropDownList>
                    </div>
                    <asp:GridView CssClass="table table-hover table-bordered mt-2" 
                        EmptyDataText="No hay Lecturas" ShowHeader="true"
                        
                        AutoGenerateColumns="false" runat="server" ID="grillaLecturas">
                        <Columns>
                            <asp:BoundField DataField="Medidor.IdMedidor" HeaderText="ID Medidor" />
                            <asp:BoundField DataField="FechaLectura" HeaderText="Fecha Lectura" />
                            <asp:BoundField DataField="Consumo" HeaderText="Consumo" />
                            <asp:BoundField DataField="Medidor.TextoTipo" HeaderText="Tipo Medidor" />
                    
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
</asp:Content>
