﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSocketUtilidades {
    public class ClienteCom {

        private Socket cliente;
        private StreamReader reader;
        private StreamWriter writer;

        public bool Escribir(string mensaje) {
            try{
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }catch (Exception) {
                return false;
            }
        }

        public string Leer() {
            try{
                return this.reader.ReadLine().Trim();
            }catch(Exception) {
                return null;
            }        
        }


        public ClienteCom(Socket socket) {
            this.cliente = socket;

            Stream stream = new NetworkStream(this.cliente);
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
        }

        public void Desconectar() {
            try { 
                
                this.cliente.Close();
                
            } catch (Exception ex) { 
            
            }

        }
    }
}
