using ServerSocketUtilidades;
using serverutilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    class Program {
        static void Main(string[] args) {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);

            if(servidor.inicaiar()) {
                Console.WriteLine("servidor iniciado");
                while(true) {
                    Console.WriteLine("Esperando clientes");
                    Socket SocketCliente = servidor.ObtenerCliente();
                    ClienteCom cliente = new ClienteCom(SocketCliente);
                    bool conexionClienteValidador = true;
                    cliente.Escribir("Bienvenido");

                    while(conexionClienteValidador) {
                        string mensajeCliente = cliente.Leer().ToLower();
                        Console.WriteLine("Cliete: {0}",mensajeCliente);
                        if(mensajeCliente.Equals("chao")) {
                            conexionClienteValidador = false;
                        } else {
                            Console.Write("Server:");
                            string mensajeServer = Console.ReadLine().Trim().ToLower();
                            cliente.Escribir(mensajeServer);

                            if(mensajeServer.Equals("chao")) {
                                conexionClienteValidador = false;
                            }
                        }

                    }

                    cliente.Desconectar();
                }
            } else {
                Console.WriteLine("Error. El puerto {0} esta en uso",puerto);
            }
        }
    }
}
