using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Comunicacion {
    public class ClienteSocket {
        private Socket conecxion;
        private string ipServer;
        private int puertoServer;
        private StreamWriter writer;
        private StreamReader reader;
        public ClienteSocket(string ipS, int puertoS) {
            this.ipServer = ipS;
            this.puertoServer = puertoS;
        }
        public bool ConexionServidor() {
          
            try {
                this.conecxion = new Socket(AddressFamily.InterNetwork,SocketType.Stream,
                                             ProtocolType.Tcp);
                IPEndPoint conector = new IPEndPoint(IPAddress.Parse(this.ipServer),this.puertoServer);
                this.conecxion.Connect(conector);
                Stream stream = new NetworkStream(this.conecxion);
                this.reader = new StreamReader(stream);
                this.writer = new StreamWriter(stream);
                return true;
            } catch(SocketException ex) {
                return false;
            }
            
           
        }

        public void CerrarConexion() {
            try {
                this.conecxion.Close();
            } catch(Exception) {

            }
        }

        
        public bool Escribir(string mensaje) {
            try {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            } catch(Exception) {
                return false;
            }
        }
        public string Leer() {
            try {
                return this.reader.ReadLine().Trim();
            } catch(Exception) {
                return null;
            }
        }
    }
}
