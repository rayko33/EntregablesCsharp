using MedidorLecturaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaMedidorDB.DAL {
    public interface ITipoMedidorDAL {
        List<TipoMedidor> ObtenerTipoMedidor();
    }
}
