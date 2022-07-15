using LecturaMedidorDB.DAL;
using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaWEB {
    public partial class AgregarLectura : System.Web.UI.Page {
        private ILecturaDAL lecturaDALDB = new LecturaDALDB();
        private IMedidorDAL medidorDALDB = new MedidorDALDB();
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                CargarDropListMedidor();
                this.lecturaFecha.SelectedDate = DateTime.Today;
                this.lecturaFecha.SelectedDayStyle.ForeColor= System.Drawing.Color.White;
                this.lecturaFecha.SelectedDayStyle.BackColor = System.Drawing.Color.Blue;
            }
        }
        private void CargarDropListMedidor() {
            List<Medidore> medidores = medidorDALDB.ObtenerMedidores();
            this.ListaMedidores.Items.Add(new ListItem("Seleccione un medidor", "0"));
            foreach(Medidore med in medidores){
                this.ListaMedidores.Items.Add(new ListItem(med.IdMedidor.ToString(), med.IdMedidor.ToString()));
            }
        }
        protected void agregarBtn_Click(object sender, EventArgs e) {
            if(Page.IsValid) {
                string fechaCombinada = this.lecturaFecha.SelectedDate.ToString();
                try {
                    DateTime fecha = DateTime.Parse(fechaCombinada);
                    fechaCombinada = fecha.ToString("dd/MM/yyyy") + " " + this.hora.Text + ":" + this.minutos.Text;
                    fecha = DateTime.Parse(fechaCombinada);
                    int idMedidor = Convert.ToInt32(this.ListaMedidores.SelectedItem.Value);

                    Lectura lectura = new Lectura();
                    lectura.Medidor = idMedidor;
                    lectura.Consumo = Convert.ToDecimal(this.consumo.Text);
                    lectura.FechaIngreso = fecha;
                    lecturaDALDB.AgregarLectura(lectura);
                    Response.Redirect("MostrarLecturas.aspx");
                } catch(Exception ex) {
                    this.mensajeLbl.Text = "Error: " + ex.Message;
                }

            }
            
            


        }

        protected void lecturaFecha_DayRender(object sender, DayRenderEventArgs e) {
            if(e.Day.Date.CompareTo(DateTime.Today) > 0) {
                
                
                e.Day.IsSelectable = false;
            }
        }

        protected void lecturaFecha_SelectionChanged(object sender, EventArgs e) {

        }
    }
}