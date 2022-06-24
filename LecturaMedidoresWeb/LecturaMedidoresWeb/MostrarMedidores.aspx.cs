using MedidorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaMedidoresWeb {
    public partial class MostrarMedidores : System.Web.UI.Page {
        private IMedidorDAL MedidorDAL = new MedidorDAL();
        protected void Page_Load(object sender,EventArgs e) {
            //cargar de prueba 
            /*if(MedidorDAL.ObtenerMedidores().Count==0) {
                for(int i = 1; i < 10; i++) {
                    Medidor medidor = new Medidor() {
                        IdMedidor = i,
                        Tipo = 2

                    };
                    MedidorDAL.IngresarMedidores(medidor);
                }
                cargaGrilla();
            }*/

            cargaGrilla();
        }

        private void cargaGrilla() {
            List<Medidor> medidor = MedidorDAL.ObtenerMedidores();
            this.grillaMedidores.DataSource = medidor;
            this.grillaMedidores.DataBind();
        }
        private void cargarGrilla(List<Medidor> filtrada) {
            this.grillaMedidores.DataSource = filtrada;
            this.grillaMedidores.DataBind();
        }
        protected void tipoMedidor_SelectedIndexChanged(object sender,EventArgs e) {
           
            if(this.tipoMedidor.SelectedItem.Value != null) {
                int nivel = Convert.ToInt32(this.tipoMedidor.SelectedItem.Value);
                List<Medidor> filtrada = MedidorDAL.Filtrar(nivel);
                cargarGrilla(filtrada);
            }
        }
    }
}