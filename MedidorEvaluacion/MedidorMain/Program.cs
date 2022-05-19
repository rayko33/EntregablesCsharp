using MedidorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorMain {
    public class Program {
        static void Main(string[] args) {
            ILecturaDAL lectura = LecutraDALArchivo.getInstancia();
            IMedidorDAL medidores = MedidorDAL.getInstancia();
            
            ThreadServer server = new ThreadServer();
            Thread threadServer = new Thread(new ThreadStart(server.EjecutarServer));
            threadServer.IsBackground = false;
            threadServer.Start();
            
            /*List<Medidor> me = medidores.ObtenerMedidores();
            foreach(Medidor med in me) {
                Console.WriteLine("{0}-{1}-{2}",med.IdMedidor,med.FechaIngreso,med.Consumo);
            }
            Console.ReadKey();*/
        }
    }
}
