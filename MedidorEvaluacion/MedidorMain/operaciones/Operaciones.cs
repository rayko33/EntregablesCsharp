using MedidorModel;
using ServerSocketUtilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MedidorMain{
    public class Operaciones {
        ILecturaDAL lectura = LecutraDALArchivo.getInstancia();
        IMedidorDAL medidores = MedidorDAL.getInstancia();

      
        public void SetServer() {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket server = new ServerSocket(puerto);
            

            if(server.inicaiar()) {

                while(true) {
                    Console.WriteLine("Esperando Medidores");
                    Socket ClienteSocket = server.ObtenerCliente();
                    ClienteCom clienteCom = new ClienteCom(ClienteSocket);

                }
            } else {
                Console.WriteLine("Error");
            }
        }
        
    }
}
