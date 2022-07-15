using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LecturaWEB {
    public partial class Usuario : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            this.NombreTxt.Enabled = false;
            this.rutTxt.Enabled = false;
            this.correoTxt.Enabled = false;
            this.passTxt.Enabled = false;
            this.mensajeLbl.Text = "Inputs Desactivados (Sitio en construccion)";
        }

        protected void agregarBtn_Click(object sender, EventArgs e) {

        }
    }
}