using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using static System.Console; 

namespace EscibirLeerDeUnArchivo
{
    class Program
    {
        static void Main(string[] args) 
        {   
            //Append
            //Create
            //CreateNew
            //Open
            //OpenOrCreate
            //Truncate
            FileStream fsEscribir = new FileStream("MiArchivoDos.txt", FileMode.Append);

            string cadena = "Estoy escribiendo una cadena y es una cadena añadida";
            fsEscribir.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0, cadena.Length);
            fsEscribir.Close();

            byte[] infoArchivo = new byte[100]; 

            FileStream fs = new FileStream("MiArchivoDos.txt", FileMode.Open);
            fs.Read(infoArchivo, 0, (int)fs.Length);
            WriteLine(ASCIIEncoding.ASCII.GetString(infoArchivo));
            ReadKey();
            fs.Close();


        }
    }
}

