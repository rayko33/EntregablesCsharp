using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaMedidorDB.DAL {
    public class TipoMedidorDALDB : ITipoMedidorDAL {
        private LecturaMedidorDBEntities lecturaMedidor = new LecturaMedidorDBEntities();

        public List<TipoMedidor> ObtenerTipoMedidor() {
            return this.lecturaMedidor.TipoMedidors.ToList();
        }
    }
}
