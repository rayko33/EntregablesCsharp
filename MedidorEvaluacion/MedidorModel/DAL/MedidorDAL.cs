using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public class MedidorDAL : IMedidorDAL {
        

       
        public static List<Medidor> medidores = new List<Medidor>();

        public bool ExisteMedidor(int id) {
            if(medidores.Find(m => m.IdMedidor == id) != null) {
                return true;
            }
            return false;
        }

        public List<Medidor> Filtrar(int tipo) {

            return medidores.FindAll(m => m.Tipo == tipo);
        }

        public void IngresarMedidores(Medidor medidor) {
            medidores.Add(medidor);
        }

        public List<Medidor> ObtenerMedidores() {
            return medidores;
        }
        
    }
}
