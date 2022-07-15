using LecturaMedidorDB.DAL;
using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaWEB {
    public partial class AgregarMedidor : System.Web.UI.Page {
        private IMedidorDAL medidorDALDB = new MedidorDALDB();
        private ITipoMedidorDAL tipoMedidorDALDB = new TipoMedidorDALDB();
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                CargarDropListTipo();
                /*this.tipo.DataSource = tipoMedidorDALDB.ObtenerTipoMedidor();
                
                this.tipo.DataTextField = "Nombre";
                this.tipo.DataValueField = "IdTipo";
                this.tipo.DataBind();*/
                
            }
        }
        private void CargarDropListTipo() {
            List<TipoMedidor> tipo = tipoMedidorDALDB.ObtenerTipoMedidor();
            this.tipo.Items.Add(new ListItem("Seleccione un tipo de medidor", "0"));
            foreach(TipoMedidor t in tipo) {
                this.tipo.Items.Add(new ListItem(t.Nombre, t.IdTipo.ToString()));
            }
        }
        protected void agregarBtn_Click(object sender, EventArgs e) {
            string idMedidor = IDTxt.Text;
            string tipo = this.tipo.SelectedItem.Value;
            int id;


            bool esIntIdMeidor = Int32.TryParse(idMedidor, out id);

            if(esIntIdMeidor) {
             
                if(!medidorDALDB.Existe(id)) {
                    Medidore medidor = new Medidore();
                    medidor.IdMedidor = id;
                    medidor.IdTipoMedidor = Convert.ToInt32(tipo);

                    medidorDALDB.AgregarMedidor(medidor);
                    this.mensajeLbl.Text = "Medidor Ingresado";
                    Response.Redirect("MostrarMedidores.aspx");
                }
                mensajeLbl.Text = "El medidor ya fue registrado ";
            } else {
                mensajeLbl.Text = "El ID debe ser numerico";
            }
        }
    }
    
}