using LecturaMedidorDB.DAL;
using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaWEB {
    public partial class MostrarLecturas : System.Web.UI.Page {
        private ILecturaDAL lecturaDALDB = new LecturaDALDB();
        private IMedidorDAL medidorDALDB = new MedidorDALDB();
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                CargarDropListMedidores();
                CargarGrilla();
            }
        }
        private void CargarGrilla(List<Lectura> filtrada) {
            this.grillaLecturas.DataSource = filtrada;
            this.grillaLecturas.DataBind();
        }
        private void CargarDropListMedidores() {
            List<Medidore> medidores = medidorDALDB.ObtenerMedidores();
            this.Medidores.Items.Add(new ListItem("Todos los Medidores","0"));
            foreach(Medidore med in medidores) {
                this.Medidores.Items.Add(new ListItem(med.IdMedidor.ToString(), med.IdMedidor.ToString()));
            }
        }
        private void CargarGrilla() {
            List<Lectura> lecturas = lecturaDALDB.ObtenerLecturas();
            this.grillaLecturas.DataSource = lecturas;
            this.grillaLecturas.DataBind();
        }
        protected void Medidores_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.Medidores.SelectedValue!=null && this.Medidores.SelectedValue!="0") {
                int idMedidor = Convert.ToInt32(this.Medidores.SelectedValue);
                List<Lectura> filtrada = lecturaDALDB.ObtenerLecturasPorMedidor(idMedidor);
                CargarGrilla(filtrada);
            } else {
                CargarGrilla();
            }
        }

        protected void grillaLecturas_RowCommand(object sender, GridViewCommandEventArgs e) {
            if(e.CommandName=="eliminar") {
                int id = Convert.ToInt32(e.CommandArgument);
                this.lecturaDALDB.EliminarLectura(id);
                this.mensajeLbl.Text = "Lectura Eliminada con exito";
                CargarGrilla();
                
            }
        }
    }
}