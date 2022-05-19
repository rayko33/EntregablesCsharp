using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace MedidorModel {
    public class LecutraDALArchivo : ILecturaDAL {
        private static LecutraDALArchivo instancia;

        private LecutraDALArchivo() {
        }
        public static ILecturaDAL getInstancia() {
            if(instancia==null) {
                instancia = new LecutraDALArchivo();
            }
            return instancia;
        }

        private static string ruta = Directory.GetCurrentDirectory();
        private static string archivo = ruta+"/lectura.txt";
        public void IngresarLectura(Medidor medidor) {
            try {
                using(StreamWriter writer = new StreamWriter(archivo,true)) {
                    writer.WriteLine(medidor.IdMedidor + "|" +
                                     medidor.FechaIngreso.ToString("yyyy-MM-dd-HH-mm-ss") + "|" +
                                     medidor.Consumo);
                    writer.Flush();
                }
            } catch(Exception e) {
                Console.WriteLine("Error: {0}",e.Message);
            }
            
        }

        public List<Medidor> ObetenerLectura() {
            List<Medidor> medidores = new List<Medidor>();
            try {
                using(StreamReader reader = new StreamReader(archivo)) {
                    string datosMedidor = "";
                    do {
                        datosMedidor = reader.ReadLine();
                        if(datosMedidor!=null) {
                            string[] arr = datosMedidor.Trim().Split('|');
                            
                            DateTime d = DateTime.ParseExact(arr[1],"yyyy-MM-dd-HH-mm-ss",null);
                           
                            Medidor medidor = new Medidor() {
                                IdMedidor = Convert.ToInt32(arr[0]),
                                FechaIngreso = d,
                                Consumo = Convert.ToDouble(arr[2])

                            };
                            medidores.Add(medidor);
                        }
                    } while(datosMedidor!=null);
                }
            } catch(Exception ex) {
                
                return null;
            }
            return medidores;
            
        }
    }
}
