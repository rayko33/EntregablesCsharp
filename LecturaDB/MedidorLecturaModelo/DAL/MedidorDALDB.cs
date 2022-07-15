using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaMedidorDB.DAL {
    public class MedidorDALDB : IMedidorDAL {
        
        private LecturaMedidorDBEntities lecturaMedidor = new LecturaMedidorDBEntities();
        public void AgregarMedidor(Medidore medidor) {
            this.lecturaMedidor.Medidores.Add(medidor);
            this.lecturaMedidor.SaveChanges();
        }

        public void EliminarMedidor(int idMedidor) {
            Medidore medidor = this.lecturaMedidor.Medidores.Find(idMedidor);
            this.lecturaMedidor.Medidores.Remove(medidor);
            this.lecturaMedidor.SaveChanges();
        }

        public bool Existe(int idMedidor) {
            Medidore medidor = ObtenerMedidor(idMedidor);

            if(medidor != null) {
                return true;
            }
            return false;
        }

        public Medidore ObtenerMedidor(int idMedidor) {
            return this.lecturaMedidor.Medidores.Find(idMedidor);
        }

        public List<Medidore> ObtenerMedidores() {
            return this.lecturaMedidor.Medidores.ToList();
        }

        public List<Medidore> ObtenerMedidorPorTipo(int tipo) {
            var query = from med in this.lecturaMedidor.Medidores where
                        med.IdMedidor == tipo select med;
            return query.ToList();
        }
    }
}
