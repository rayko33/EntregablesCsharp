using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public interface IMedidorDAL {
        List<Medidor> ObtenerMedidores();
        void IngresarMedidores(Medidor medidor);

        List<Medidor> Filtrar(int tipo);
        bool ExisteMedidor(int id);
        
    }
}
