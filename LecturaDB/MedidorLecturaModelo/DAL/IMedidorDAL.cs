using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaMedidorDB.DAL {
    public interface IMedidorDAL {
        void AgregarMedidor(Medidore medidor);
        List<Medidore> ObtenerMedidores();
        Medidore ObtenerMedidor(int idMedidor);
        List<Medidore> ObtenerMedidorPorTipo(int tipo);
        bool Existe(int idMedidor);
        void EliminarMedidor(int idMedidor);

    }
}
