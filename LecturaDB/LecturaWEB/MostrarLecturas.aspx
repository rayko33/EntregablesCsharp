<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MostrarLecturas.aspx.cs" Inherits="LecturaWEB.MostrarLecturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView CssClass="table table-hover table-bordered mt-2"
                                EmptyDataText="No hay Lecturas" ShowHeader="true"
                                OnRowCommand="grillaLecturas_RowCommand"
                                AutoGenerateColumns="false" runat="server" ID="grillaLecturas">
                                <Columns>
                                    <asp:BoundField DataField="IdLectura" HeaderText="ID Lectura" />
                                    <asp:BoundField DataField="Medidore.IdMedidor" HeaderText="ID Medidor" />
                                    <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Lectura" />
                                    <asp:BoundField DataField="Consumo" HeaderText="Consumo" />
                                    <asp:BoundField DataField="Medidore.TipoMedidor.Nombre" HeaderText="Tipo Medidor" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button
                                                CommandName="eliminar"
                                                CommandArgument='<%# Eval("IdLectura") %>'
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
