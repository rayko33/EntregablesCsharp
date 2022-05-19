using Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorCliente {
   public  class Program {
        
        static void Main(string[] args) {
            
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string servidor = ConfigurationManager.AppSettings["ipServer"];

            ClienteSocket medidorCliente = new ClienteSocket(servidor,puerto);
            if(medidorCliente.ConexionServidor()){
                Console.WriteLine("Conectado a {0}/{1}",servidor,puerto);
                medidorCliente.Escribir(IngresarDatos());
                Console.WriteLine(medidorCliente.Leer()); 
                
                medidorCliente.CerrarConexion();
            } else {
                Console.WriteLine("Error de conexion");
            }
            Console.ReadKey();
        }
        public static string IngresarDatos() {
            int id;
            double consumo;
            string lectura;
            DateTime fecha;

            bool esValido;
            do {
                Console.WriteLine("Ingrese ID del medidor");
                esValido = Int32.TryParse(Console.ReadLine().Trim(),out id);
                if(!esValido) {
                    Console.WriteLine("El ID debe ser numerico entero (1;2;3...)");
                }
            } while(!esValido);
            do {
                Console.WriteLine("Ingrese consumo");
                esValido = Double.TryParse(Console.ReadLine().Trim(),out consumo);
                if(!esValido) {
                    Console.WriteLine("El consumo debe ser decimal (3,5;50,6...)");
                }
            } while(!esValido);
            fecha = DateTime.Now;
             
            lectura = id+"|"+ fecha.ToString("yyyy-MM-dd-HH-mm-ss") + "|"+ consumo;
            Console.WriteLine(lectura);
            return lectura;
        }
    }
}
