﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel {
    public interface ILecturaDAL {
        void IngresarLectura(Medidor medidor);
        List<Medidor> ObetenerLectura();
    }
}
