using clienteutilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente {
    class Program {
        static void Main(string[] args) {
            ClienteSocket serverConect = new ClienteSocket();
            serverConect.InicializarConexion();
            bool ConexionValidador = true;
            if(serverConect.ConexionServidor()) {
                Console.WriteLine("Conectado");
                while(ConexionValidador) {
                    string mensajeServer = serverConect.Leer().ToLower();
                    Console.WriteLine("server: {0}",mensajeServer);
                    if(mensajeServer.Equals("chao")) {
                        ConexionValidador = false;
                    } else {
                        Console.Write("Cliente:");
                        string mensajeCliente = Console.ReadLine().Trim().ToLower();
                        serverConect.Escribir(mensajeCliente);
                        if(mensajeCliente.Equals("chao")) {
                            ConexionValidador = false;
                        }
                    }


                }


            } else {
                Console.WriteLine("Algo salio mal");
                Console.ReadKey();
            }
        }
    }
}
