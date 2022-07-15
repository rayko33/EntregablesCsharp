<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AgregarLectura.aspx.cs" Inherits="LecturaWEB.AgregarLectura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="row">
        <div class="col-lg-4 mx-auto">
            <div class="mensaje">
                <asp:Label runat="server" ID="mensajeLbl" CssClass="text-success"></asp:Label>
            </div>
            <div class="card">
                <div class="card-header bg-dark text-white">
                    <h3>Agregar Lectura</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="ListaMedidores">ID Medidor</label>
                        
                        <asp:DropDownList runat="server" ID="ListaMedidores" CssClass="form-select">

                        </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="Medidor" runat="server"
                            ControlToValidate="ListaMedidores" ErrorMessage="Se requiere seleccionar un medidor" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                        <label for="lecturaFecha">Fecha</label>
                        
                        <asp:Calendar runat="server" ID="lecturaFecha" CssClass="form-group" OnDayRender="lecturaFecha_DayRender" OnSelectionChanged="lecturaFecha_SelectionChanged" >
                            

                        </asp:Calendar>
                        
                    </div>
                    <div class="form-group mt-2">
                        <label for="hora">HRS</label>
                        <asp:TextBox runat="server" ID="hora" CssClass="form-group" placeholder="00" MaxLength="2" ></asp:TextBox>

                        <asp:RequiredFieldValidator ID="requiredHoras" runat="server"
                            ControlToValidate="hora" ErrorMessage="Se requiere ingreso de horas" ForeColor="Orange"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rangehoras" runat="server" ControlToValidate="hora" ForeColor="Red"
                            MinimumValue="0" MaximumValue="23" ErrorMessage="las horas no debe ser mayor a 23 y menos que 0" Type="String"></asp:RangeValidator>
                        
                    </div>
                    <div class="form-group mt-2">
                        
                        <label for="minutos">Min</label>
                        <asp:TextBox runat="server" ID="minutos" CssClass="form-group" MaxLength="2" placeholder="00"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="requiredMin" runat="server"
                            ControlToValidate="minutos" ErrorMessage="Se requiere ingreso de minutos" ForeColor="Orange" ></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rangeMin" runat="server" ControlToValidate="minutos" ForeColor="Red"
                            MinimumValue="0" MaximumValue="59" ErrorMessage="los minutos no debe ser mayor a 59 y menos que 0" Type="String"></asp:RangeValidator>
                    </div>
                    <div class="form-group mt-2">
                        <label for="consumo">Consumo</label>
                        <asp:TextBox runat="server" ID="consumo" CssClass="form-control"></asp:TextBox>
                        <asp:RangeValidator ID="consumoRangoValidador" runat="server"
                            ErrorMessage="El rango debe de ser entre 0 a 600" ControlToValidate="consumo" ForeColor="Red"
                            MinimumValue="0" MaximumValue="600" Type="Double">

                        </asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="requiredConsumo" runat="server"
                            ControlToValidate="consumo" ErrorMessage="Se requiere ingreso del consumo" ForeColor="Orange" ></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group mt-2">
                        <asp:Button runat="server" ID="agregarBtn" OnClick="agregarBtn_Click"
                            Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
