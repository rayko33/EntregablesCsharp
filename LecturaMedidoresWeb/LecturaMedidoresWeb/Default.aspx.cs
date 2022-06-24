using MedidorModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaMedidoresWeb {
    public partial class Default : System.Web.UI.Page {
       
        private IMedidorDAL MedidorDAL = new MedidorDAL();
        protected void Page_Load(object sender,EventArgs e) {
            
                
              
            
        }

        protected void agregarBtn_Click(object sender,EventArgs e) {
            string idMedidor= IDTxt.Text;
            string tipo = this.tipo.SelectedItem.Value;
            int id;
            
            
            bool esIntIdMeidor = Int32.TryParse(idMedidor,out id);
            
            if(esIntIdMeidor) {
                List<Medidor> medidores = MedidorDAL.Filtrar(id);
                if(!MedidorDAL.ExisteMedidor(id)) {
                    Medidor medidor = new Medidor() {
                        IdMedidor = id,
                        Tipo = Convert.ToInt32(tipo)
                    };
                    MedidorDAL.IngresarMedidores(medidor);
                    this.mensajeLbl.Text = "Medidor Ingresado";
                    Response.Redirect("MostrarMedidores.aspx");
                }
                mensajeLbl.Text = "El medidor ya fue registrado";
            } else {
                mensajeLbl.Text = "El ID debe ser numerico";
            }
            /*int id = Convert.ToInt32(this.IDTxt.Text);
            int tipo = Convert.ToInt32(this.tipo.SelectedValue);
           
            MedidorDAL.IngresarMedidores(medidor);
            this.mensajeLbl.Text="Medidor Ingresado";
            Response.Redirect("MostrarMedidores.aspx");*/
        }
    }
}