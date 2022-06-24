using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public class Lectura {
        private double consumo;
        private DateTime fechaLectura;
        private Medidor medidor;
        public double Consumo {
            get => consumo;
            set => consumo = value;
        }
        public DateTime FechaLectura {
            get => fechaLectura;
            set => fechaLectura = value;
        }
        public Medidor Medidor {
            get => medidor;
            set => medidor = value;
        }
    }
}
