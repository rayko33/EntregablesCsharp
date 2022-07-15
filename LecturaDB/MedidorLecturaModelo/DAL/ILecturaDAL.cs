using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaMedidorDB.DAL {
    public interface ILecturaDAL {
        void AgregarLectura(Lectura lectura);
        List<Lectura> ObtenerLecturas();
        List<Lectura> ObtenerLecturasPorMedidor(int idMedidor);
        void EliminarLectura(int idLectura);
    }
}
