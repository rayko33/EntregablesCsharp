using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public class MedidorDAL : IMedidorDAL {
        private ILecturaDAL lectura = LecutraDALArchivo.getInstancia();
        private static MedidorDAL instancia;

        private MedidorDAL() {
        }
        public static IMedidorDAL getInstancia() {
            if(instancia == null) {
                instancia = new MedidorDAL();
            }
            return instancia;
        }
        public static List<Medidor> medidores;
        public List<Medidor> ObtenerMedidores() {
            medidores = new List<Medidor>(lectura.ObetenerLectura());
            return medidores;
        }
    }
}
