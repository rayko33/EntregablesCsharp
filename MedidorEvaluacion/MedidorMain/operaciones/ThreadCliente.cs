using MedidorModel;
using ServerSocketUtilidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorMain {
    public class ThreadCliente {
        ClienteCom clienteCom;
        ILecturaDAL lectura = LecutraDALArchivo.getInstancia();
        IMedidorDAL medidores = MedidorDAL.getInstancia();
     
        public ThreadCliente(ClienteCom cliente) { 
            this.clienteCom = cliente;
        }

        public void EjecutarIngreso() {
            string lecturaClienteMedidor;
            string formato = "yyyy-MM-dd-HH-mm-ss";
            lecturaClienteMedidor = clienteCom.Leer();
         
            string[] datos = lecturaClienteMedidor.Split('|');
            int id = Convert.ToInt32(datos[0]);
            if(!ExisteMedidor(id)){
                clienteCom.Escribir("Error... Medidor no encontrado. Desconectando");
            } else {
                Medidor medidor = new Medidor() {
                    IdMedidor = id,
                    Consumo = Convert.ToDouble(datos[2]),
                    FechaIngreso = DateTime.ParseExact(datos[1],formato,null)
                };

                lock(lectura) {
                    lectura.IngresarLectura(medidor);
                    
                }
                clienteCom.Escribir("Lectura Ingresada");
            }
            clienteCom.Desconectar();

        }
        private  bool ExisteMedidor(int id) {
            bool respuesta=false;
            List<Medidor> medidor = new List<Medidor>(medidores.ObtenerMedidores());
            foreach(Medidor med in medidor) {
                if(med.IdMedidor==id){
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }
    }
}
