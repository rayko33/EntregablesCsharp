using MedidorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaMedidoresWeb {
    public partial class MostrarLectura : System.Web.UI.Page {
        private ILecturaDAL LecturaDAL = new LecturaDALObjeto();
        public IMedidorDAL MedidorDAL = new MedidorDAL();
        protected void Page_Load(object sender,EventArgs e) {
            if(!IsPostBack) {
                List<Lectura> lecturas = LecturaDAL.ObetenerLectura();
                this.grillaLecturas.DataSource = lecturas;
                this.DataBind();
                List<Medidor> medidores = MedidorDAL.ObtenerMedidores();
                this.Medidores.Items.Add(new ListItem("Seleccione un medidor","0"));
                foreach(Medidor items in medidores) {
                    this.Medidores.Items.Add(new ListItem(items.IdMedidor.ToString(),items.IdMedidor.ToString()));
                }
            }
        }

        private void cargarGrilla(List<Lectura> filtrada) {
            this.grillaLecturas.DataSource = filtrada;
            this.grillaLecturas.DataBind();
        }
        private void cargarGrilla() {
            List<Lectura> lecturas = LecturaDAL.ObetenerLectura();
            this.grillaLecturas.DataSource = lecturas;
            this.grillaLecturas.DataBind();
        }
        protected void Medidores_SelectedIndexChanged(object sender,EventArgs e) {
            if(this.Medidores.SelectedItem.Value != null && this.Medidores.SelectedValue!="0") {
                int idMedidor = Convert.ToInt32(this.Medidores.SelectedItem.Value);
                List<Lectura> filtrada = LecturaDAL.Filtrar(idMedidor);
                cargarGrilla(filtrada);
            } else {
                cargarGrilla();
            }
        }
    }
}