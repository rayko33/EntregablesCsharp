using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace MedidorModel {
    public class LecturaDALObjeto : ILecturaDAL {
        public static List<Lectura> lecturas = new List<Lectura>();

        public List<Lectura> Filtrar(int idMedidor) {
            return lecturas.FindAll(medidor => medidor.Medidor.IdMedidor == idMedidor);
        }

        public void IngresarLectura(Lectura lectura) {
            lecturas.Add(lectura);
            
        }

        public List<Lectura> ObetenerLectura() {
           
            return lecturas;
            
        }
    }
}
