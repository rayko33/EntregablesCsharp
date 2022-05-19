using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace clienteutilidades {
    public class ClienteSocket {
        private Socket conecxion;
        private string ip;
        private int puerto;
        private StreamWriter writer;
        private StreamReader reader;
        public ClienteSocket() {
            
        }
        public bool ConexionServidor() {
          
            try {
                this.conecxion = new Socket(AddressFamily.InterNetwork,SocketType.Stream,
                                             ProtocolType.Tcp);
                IPEndPoint conector = new IPEndPoint(IPAddress.Parse(this.ip),this.puerto);
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

        public void InicializarConexion() {
            int puerto;
            string ip;
            bool esValido;


            do {
                Console.WriteLine("Ingrese la puerto del servidor:");
                esValido = Int32.TryParse(Console.ReadLine(),out puerto);
               
                if(!esValido) {
                    Console.WriteLine("El puerto debe de ser numerico");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while(!esValido);

            do {
                Console.WriteLine("Inrese la ip del servidor");
                ip = Console.ReadLine();
                if(ip.Equals("")) {
                    Console.WriteLine("Ingrese una ip valida");

                }
            } while(ip.Equals(""));

            this.puerto = puerto;
            this.ip = ip;
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
