using LecturaMedidorDB.DAL;
using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaWEB {
    public partial class MostrarMedidores : System.Web.UI.Page {
        private IMedidorDAL medidorDALDB = new MedidorDALDB();
        private ITipoMedidorDAL tipoMedidorDALDB = new TipoMedidorDALDB();
        
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                CargarDropListoTipo();
                CargarGrilla();
                
            }
        }
        private void CargarDropListoTipo() {
            List<TipoMedidor> tipo = tipoMedidorDALDB.ObtenerTipoMedidor();
            this.tipoMedidor.Items.Add(new ListItem("Todos los medidores", "0"));
            foreach(TipoMedidor t in tipo) {
                this.tipoMedidor.Items.Add(new ListItem(t.Nombre, t.IdTipo.ToString()));
            }
        }
        private void CargarGrilla(List<Medidore> medidores) {
            this.grillaMedidores.DataSource = medidores;
            this.grillaMedidores.DataBind();
        }
        private void CargarGrilla() {
            List<Medidore> medidores;
            int tipo = Convert.ToInt32(this.tipoMedidor.SelectedItem.Value);
            if(tipo == 0) {
                medidores = this.medidorDALDB.ObtenerMedidores();
            } else {
                medidores = this.medidorDALDB.ObtenerMedidorPorTipo(tipo);
            }
            CargarGrilla(medidores);
        }
        protected void tipoMedidor_SelectedIndexChanged(object sender, EventArgs e) {
            CargarGrilla();
        }

        protected void grillaMedidores_RowCommand(object sender, GridViewCommandEventArgs e) {
            if(e.CommandName =="eliminar") {
                int id = Convert.ToInt32(e.CommandArgument);
                medidorDALDB.EliminarMedidor(id);
                CargarGrilla();
            }
        }
    }
}