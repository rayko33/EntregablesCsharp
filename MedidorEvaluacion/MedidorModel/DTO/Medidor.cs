using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public class Medidor {
        private int idMedidor;
        private int tipo;
        

        public string Textotipo{
            get {
                string tipoTxt = "";
                switch(tipo) {
                    case 1:
                        tipoTxt = "Smart";
                        break;
                    case 2:
                        tipoTxt = "Convencional";
                        break;
                }
                return tipoTxt;
            }
            
        }
        public int IdMedidor {
            get => idMedidor;
            set => idMedidor = value;
        }
   
        public int Tipo {
            get => tipo;
            set => tipo = value;
        }
        
    }
}
