using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIII_Examen_1
{
    //Desarrollado por: Jose Antonio Valerio - Progamacion III - UPI - 2023
    internal class ClsEmpleado
    {
        public int[] cedula = new int[20];
        public string[] nombre = new string[20];
        public string[] direccion = new string[20];
        public int[] telefono = new int[20];
        public double[] salario = new double[20];

        public ClsEmpleado()
        {

        }

        public void InicializarArreglos()
        {
            cedula = Enumerable.Repeat(0, 20).ToArray();
            nombre = Enumerable.Repeat(String.Empty, 20).ToArray();
            direccion = Enumerable.Repeat(String.Empty, 20).ToArray();
            telefono = Enumerable.Repeat(0, 20).ToArray();
            salario = Enumerable.Repeat(0.0, 20).ToArray();

            foreach (int i in cedula)
            {
                Console.WriteLine(i);
            }
            foreach (string i in nombre)
            {
                Console.WriteLine(i);
            }
            foreach (string i in direccion)
            {
                Console.WriteLine(i);
            }
            foreach (int i in telefono)
            {
                Console.WriteLine(i);
            }
            foreach (int i in salario)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("****** Arreglos Inicializados, presione cualquier tecla para continuar ******");
            Console.ReadKey();

            // Cargar datos temporales:

            cedula[1] = 402440919;
            nombre[1] = "Jose Antonio Valerio Chaves";
            direccion[1] = "Heredia, Costa Rica";
            telefono[1] = 88092323;
            salario[1] = 1150000;

            cedula[2] = 40404040;
            nombre[2] = "Rafael Angel Calderon Guardia";
            direccion[2] = "San Jose, Costa Rica";
            telefono[2] = 40404040;
            salario[2] = 600000;

            cedula[0] = 20202020;
            nombre[0] = "Juan Santa Maria Alajuela";
            direccion[0] = "Alajuela, Costa Rica";
            telefono[0] = 20202020;
            salario[0] = 850000;
        }

        public int BuscarEmpleado(int id)
        {
            int pos = -1;
            for (int i = 0; i < 20; i++)
            {
                if (id == cedula[i])
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public void ExtraerDatosSalario(double monto)
        {
            Console.WriteLine("Cedula\t\tNombre\t\t\t\tDireccion\t\tTelefono\tSalario");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < 20; i++)
            {
                if (salario[i] == monto)
                {
                    Console.WriteLine($"{cedula[i]}\t{nombre[i]}\t{direccion[i]}\t{telefono[i]}\t{salario[i]}");
                }
            }
            Console.WriteLine("========================================================================================================");
        }
    }
}
