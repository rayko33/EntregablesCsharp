using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ServerSocketUtilidades {
    public class ServerSocket {
        private int puerto;
        private Socket servidor;

        public ServerSocket(int puerto) {
            this.puerto = puerto;
        }

        public bool inicaiar() {
            try {
                this.servidor = new Socket(AddressFamily.InterNetwork,
                                            SocketType.Stream, ProtocolType.Tcp);
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                this.servidor.Listen(10);
                return true;
            } catch (SocketException ex) {
                return false;
            }
        }

        public Socket ObtenerCliente() {
            return this.servidor.Accept();
        }

        public void cerrar() {
            try {
                this.servidor.Close();
            } catch (Exception) {

            }
        }
    }
}
