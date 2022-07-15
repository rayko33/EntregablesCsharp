using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaMedidorDB.DAL {
    public class LecturaDALDB : ILecturaDAL {
        private LecturaMedidorDBEntities lecturaMedidor = new LecturaMedidorDBEntities();
        public void AgregarLectura(Lectura lectura) {
            this.lecturaMedidor.Lecturas.Add(lectura);
            this.lecturaMedidor.SaveChanges();
        }

        public void EliminarLectura(int idLectura) {
            Lectura lectura = this.lecturaMedidor.Lecturas.Find(idLectura);
            this.lecturaMedidor.Lecturas.Remove(lectura);
            this.lecturaMedidor.SaveChanges();
        }

        public List<Lectura> ObtenerLecturas() {
            return this.lecturaMedidor.Lecturas.ToList();
        }

        public List<Lectura> ObtenerLecturasPorMedidor(int idMedidor) {
            var query = from lec in this.lecturaMedidor.Lecturas 
                        where lec.Medidor == idMedidor select lec;
            return query.ToList();  
        }
    }
}
