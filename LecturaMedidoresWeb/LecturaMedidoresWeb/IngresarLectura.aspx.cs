using MedidorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaMedidoresWeb {
    public partial class IngresarLectura : System.Web.UI.Page {
        public ILecturaDAL LecturaDAL = new LecturaDALObjeto();
        public IMedidorDAL MedidorDAL = new MedidorDAL();
        protected void Page_Load(object sender,EventArgs e) {
            if(!IsPostBack) {
                
                List<Medidor> medidores = MedidorDAL.ObtenerMedidores();
                this.ListaMedidores.Items.Add(new ListItem("Seleccione un medidor","0"));
                foreach(Medidor items in medidores) {
                    this.ListaMedidores.Items.Add(new ListItem(items.IdMedidor.ToString(),items.IdMedidor.ToString()));
                }
                
            }
        }

        protected void lecturaFecha_DayRender(object sender,DayRenderEventArgs e) {
            if(e.Day.Date.CompareTo(DateTime.Today) > 0) {
                e.Day.IsSelectable = false;
            }
        }

       

        

        protected void agregarBtn_Click(object sender,EventArgs e) {
            if(Page.IsValid) {
                string fechaCombinada = this.lecturaFecha.SelectedDate.ToString();
                try {
                    DateTime fecha = DateTime.Parse(fechaCombinada);
                    fechaCombinada = fecha.ToString("dd/MM/yyyy") + " " + this.hora.Text + ":" + this.minutos.Text;
                    fecha = DateTime.Parse(fechaCombinada);
                    int idMedidor = Convert.ToInt32(this.ListaMedidores.SelectedItem.Value);
                    //mensajeLbl.Text = fechaCombinada;
                    List<Medidor> medidores = MedidorDAL.ObtenerMedidores();
                    Medidor medidor = medidores.Find(m => m.IdMedidor == idMedidor);
                    Lectura lectura = new Lectura() {
                        FechaLectura = fecha,
                        Consumo = Convert.ToDouble(this.consumo.Text),
                        Medidor = medidor
                    };
                    LecturaDAL.IngresarLectura(lectura);
                    Response.Redirect("MostrarLectura.aspx");
                } catch(Exception ex) {
                    mensajeLbl.Text = "Error";
                }

            }
        }
            

       

        protected void customHorasValidador_ServerValidate(object source,ServerValidateEventArgs args) {
            this.mensajeLbl.Text = args.Value.GetType().ToString();
            

        }

        protected void lecturaFecha_SelectionChanged(object sender,EventArgs e) {
            
        }

    
    }
}