using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public class Medidor {
        private int idMedidor;
        private DateTime fechaIngreso;
        private double consumo;

        public int IdMedidor {
            get => idMedidor;
            set => idMedidor = value;
        }
        public DateTime FechaIngreso {
            get => fechaIngreso;
            set => fechaIngreso = value;
        }
        public double Consumo {
            get => consumo;
            set => consumo = value;
        }
    }
}
