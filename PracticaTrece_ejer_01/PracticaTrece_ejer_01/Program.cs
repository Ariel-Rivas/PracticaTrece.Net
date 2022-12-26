using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//1- Crear un programa que realice la siguiente funcionalidad:

//Se pedirá por consola el nombre de una persona, su edad y su localidad, se guardara en un archivo con el siguiente formato, nombre|edad|localidad;  uno detrás del otro "|" separa datos ";" separa registros.Cuando se inserte, se pedirá si quiere introducir más personas, "S o N", se podrán introducir personas hasta que se pulse en "N". cuando se pulse en "N", se listaran todas las personas que están introducidas en el archivo.

//una vez se salga del programa, si lo volvemos a ejecutar e introducimos mas personas, una vez pulsado de nuevo "N", tendrán que salir todas las personas, las introducidas en veces anteriores y las nuevas.

//Requisitos: se tendrán que usar todos los componentes vistos hasta la fecha, clases (Clase persona), propiedades, Interfaces, métodos, funciones, bucles, condicionales control de excepciones y archivos.

//Cuidado: tienes que realizar todas las comprobaciones necesarias de validaciones.




namespace PracticaTrece_ejer_01
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("miArchivo.txt", FileMode.OpenOrCreate);
            fs.Close();

            string opcion = "S";

            FileStream fs2 = new FileStream("miArchivo.txt", FileMode.Append);

            while ( opcion == "S")
            {
                WriteLine("Ingrese el nombre de la persona ");
                var Nombre = ReadLine();

                WriteLine("Ingrese la edad de la persona ");
                var Edad = ReadLine();

                WriteLine("Ingrese la localidad de la persona ");
                var Localidad = ReadLine();


                string persona = $"{Nombre}|{Edad}|{Localidad};";

                fs2.Write(ASCIIEncoding.ASCII.GetBytes(persona), 0, persona.Length);

                Console.WriteLine("Quieres introducir otra persona? S o N?");
                opcion = Console.ReadLine().ToUpper();
            }
            fs2.Close();

            byte[] infoArchivo = new byte[500000];

            FileStream fs3 = new FileStream("miArchivo.txt", FileMode.Open);
            fs3.Read(infoArchivo, 0, (int)fs3.Length);
            fs3.Close();

            var archivo = ASCIIEncoding.ASCII.GetString(infoArchivo);

            var personas = archivo.Split(';').ToList();

            personas.RemoveAt(personas.Count - 1);

            foreach (var item in personas)
            {
                var persona = ExtractPersona(item);
                Console.WriteLine($"El nombre es {persona.Nombre} su edad es {persona.Edad} y su localidad es {persona.Localidad}");
            }


            Console.ReadKey();
        }

        public static Persona ExtractPersona(string linea)
        {

            var persona = linea.Split('|');

            return new Persona
            {
                Edad = (persona[1]),
                Localidad = persona[2],
                Nombre = persona[0]
               
        };
             
        }
     
    }

}

       