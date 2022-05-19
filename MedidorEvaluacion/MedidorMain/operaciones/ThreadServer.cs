using MedidorModel;
using ServerSocketUtilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorMain {
    public class ThreadServer {
        ILecturaDAL lectura = LecutraDALArchivo.getInstancia();
        public void EjecutarServer() {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);
            Random rand = new Random();
            Console.WriteLine("S: Iniciando servidor en puerto {0}",puerto);
            if(servidor.inicaiar()) {
                if(lectura.ObetenerLectura() == null) {

                    for(int i = 1; i <= 10; i++) {
                        double consumo = rand.NextDouble() * (200.9 - 50.1) + 50.1;
                        Medidor med = new Medidor() {
                            IdMedidor = i,
                            Consumo = Math.Round(consumo,2),
                            FechaIngreso = DateTime.Now,
                        };
                        lectura.IngresarLectura(med);
                    }
                }
                while(true) {
                    Console.WriteLine("S: Esperando Cliente...");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("S: Cliente recibido");

                    
                    ClienteCom clienteCom = new ClienteCom(cliente);

                    ThreadCliente clienteThread = new ThreadCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteThread.EjecutarIngreso));
                    t.IsBackground = true;
                    t.Start();

                }
            } else {
                Console.WriteLine("Fail, no se puede conextar al server en {0}",puerto);
            }
        }
    }
}
