using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using PIII_Examen_1;

namespace PIII_Examen_1
{
    //Desarrollado por: Jose Antonio Valerio - Progamacion III - UPI - 2023
    internal class ClsMenu
    {
        ClsEmpleado Empleado = new ClsEmpleado();
        int opc = 0; //Variable Global
        int opc2 = 0; //Variable Global
        public void menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Por favor seleccione una opcion:");
                Console.WriteLine("  1. Inicializar Empleados.");
                Console.WriteLine("  2. Agregar Empleados.");
                Console.WriteLine("  3. Modificar Empleados.");
                Console.WriteLine("  4. Borrar Empleados.");
                Console.WriteLine("  5. Consultar Empleados.");
                Console.WriteLine("  6. Reportes.");
                Console.WriteLine("  7. Salir.");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1: // Inicializar Empleados
                        Empleado.InicializarArreglos();
                        break;
                    case 2: // Agregar Empleados.
                        AgregarEmpleado();
                        break;
                    case 3: // Modificar Empleados.
                        Console.WriteLine("********** MODIFICAR EMPLEADO *******");
                        Console.WriteLine("Ingrese el numero de cedula del empleado a modificar: ");
                        ModificarEmpleado(int.Parse(Console.ReadLine()));
                        break;
                    case 4: // Borrar Empleados.
                        Console.WriteLine("********** BORRAR EMPLEADO *******");
                        Console.WriteLine("Ingrese el numero de cedula del empleado a eliminar: ");
                        EliminarEmpleado(int.Parse(Console.ReadLine()));
                        break;
                    case 5: // Consultar Empleados.
                        Console.WriteLine("********** CONSULTA DE EMPLEADO *******");
                        Console.WriteLine("Ingrese el numero de cedula del empleado a consultar: ");
                        ConsultarEmpleado(int.Parse(Console.ReadLine()));
                        break;
                    case 6: // Reportes.
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t SUBMENU - REPORTES");
                            Console.WriteLine("Por favor seleccione una opcion de reportes:");
                            Console.WriteLine("  1. Consultar empleados con número de cédula.");
                            Console.WriteLine("  2. Listar todos los empleados.");
                            Console.WriteLine("  3. Calcular y mostrar el promedio de los salarios.");
                            Console.WriteLine("  4. Calcular y mostrar el salario más alto y el más bajo de todos los empleados.");
                            Console.WriteLine("  5. Regresar.");
                            opc2 = Convert.ToInt32(Console.ReadLine());
                            switch (opc2)
                            {
                                case 1: // Consultar empleados con número de cédula
                                    Console.WriteLine("********** CONSULTA DE EMPLEADO *******");
                                    Console.WriteLine("Ingrese el numero de cedula del empleado a consultar: ");
                                    ConsultarEmpleado(int.Parse(Console.ReadLine()));
                                    break;
                                case 2: // Listar todos los empleados ordenados por nombre utilizando una función con parámetros.
                                    verTodosEmpleados();
                                    break;
                                case 3: // Calcular y mostrar el promedio de los salarios utilizando una función con parámetros.
                                    AvgSalario();
                                    break;
                                case 4: // Calcular y mostrar el salario más alto y el más bajo de todos los empleados utilizando funciones con parámetros.
                                    MinMaxSalario();
                                    break;
                                case 5: // Salir
                                    break;
                                default:
                                    Console.WriteLine("Opcion invalida, intente de nuevo.");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (opc2 != 5);
                        break;
                    case 7:
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, intente de nuevo.");
                        Console.ReadLine();
                        break;
                }
            } while (opc != 7);
        }

        public void AgregarEmpleado()
        {
            int cedulaTemp = 0;
            string nombreTemp = " ";
            string direccionTemp = " ";
            int telefonoTemp = 0;
            double salarioTemp = 0.0;
            string almacenar;
            Boolean existe = false;
            Console.WriteLine("******** REGISTRAR EMPLEADO ********");
            Console.WriteLine("Ingrese la cedula del empleado: ");
            cedulaTemp = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre completo del empleado: ");
            nombreTemp = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del empleado: ");
            direccionTemp = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del empleado: ");
            telefonoTemp = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el salario del empleado: ");
            salarioTemp = double.Parse(Console.ReadLine());
            Console.WriteLine(" ");

            Console.WriteLine("Cedula\t\tNombre\t\t\t\tDireccion\t\tTelefono\tSalario");
            Console.WriteLine("========================================================================================================");
            Console.WriteLine($"{cedulaTemp}\t{nombreTemp}\t{direccionTemp}\t{telefonoTemp}\t{salarioTemp}");
            Console.WriteLine("========================================================================================================");
            Console.WriteLine("Desea almacenar el registro anterior? (Y/N)");
            almacenar = Convert.ToString(Console.ReadLine().ToLower());

            //Validar si ya existe
            if (Empleado.BuscarEmpleado(cedulaTemp) != -1)
            {
                existe = true;
                Console.WriteLine($"La cedula ingresada ya existe en la base de datos");
                Console.ReadLine();
            }

            if (almacenar.Equals("y") & existe == false)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (Empleado.cedula[i] == 0)
                    {
                        Empleado.cedula[i] = cedulaTemp;
                        Empleado.nombre[i] = nombreTemp;
                        Empleado.direccion[i] = direccionTemp;
                        Empleado.telefono[i] = telefonoTemp;
                        Empleado.salario[i] = salarioTemp;

                        Console.WriteLine("Los datos han sido almacenados en la base de datos.");
                        Console.ReadLine();
                        i = 20;
                    }
                }
            }
            else if (almacenar.Equals("n") || existe == true)
            {
                Console.WriteLine("Los datos ingresados no seran almacenados.");
                Console.ReadLine();
            }
        }

        public void verTodosEmpleados()
        {
            Console.WriteLine("Cedula\t\tNombre\t\t\t\tDireccion\t\tTelefono\tSalario");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < 20; i++)
            {
                if (Empleado.cedula[i] != 0)
                {
                    Console.WriteLine($"{Empleado.cedula[i]}\t{Empleado.nombre[i]}\t{Empleado.direccion[i]}\t{Empleado.telefono[i]}\t{Empleado.salario[i]}");
                }
            }
            Console.WriteLine("========================================================================================================");
            Console.WriteLine(" ");
            var nombresOrdenados = Empleado.nombre.Where(nombre => !string.IsNullOrWhiteSpace(nombre)).OrderBy(n => n);
            Console.WriteLine(" Nombres ordenados alfabeticamente");
            Console.WriteLine("===================================");
            foreach (string nombre in nombresOrdenados)
            {
                Console.WriteLine(nombre);
            }
            Console.WriteLine("===================================");
            Console.ReadLine();
        }

        public void ConsultarEmpleado(int ced)
        {
            int pos = Empleado.BuscarEmpleado(ced);
            if (Empleado.BuscarEmpleado(ced) == -1)
            {
                Console.WriteLine($"No se encontró registro con la cédula ingresada: {ced}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Cédula\t\tNombre\t\t\t\tDirección\t\tTeléfono\tSalario");
                Console.WriteLine("========================================================================================================");
                Console.WriteLine($"{Empleado.cedula[pos]}\t{Empleado.nombre[pos]}\t{Empleado.direccion[pos]}\t{Empleado.telefono[pos]}\t{Empleado.salario[pos]}");
                Console.WriteLine("========================================================================================================");
                Console.WriteLine("\t\t\t\t   <PULSE CUALQUIER TECLA PARA CONTINUAR>");
                Console.ReadKey();
            }
        }

        public void ModificarEmpleado(int ced)
        {
            int pos = Empleado.BuscarEmpleado(ced);
            Console.WriteLine("Los datos actuales del registro son: ");
            ConsultarEmpleado(ced);
            int cedulaTemp = 0;
            string nombreTemp = " ";
            string direccionTemp = " ";
            int telefonoTemp = 0;
            double salarioTemp = 0.0;
            string almacenar;
            Console.WriteLine("******** MODIFICAR  EMPLEADO ********");
            Console.WriteLine("Ingrese la cedula del empleado: ");
            cedulaTemp = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre completo del empleado: ");
            nombreTemp = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del empleado: ");
            direccionTemp = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del empleado: ");
            telefonoTemp = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el salario del empleado: ");
            salarioTemp = double.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("******** LOS NUEVOS DATOS SON ********");
            Console.WriteLine("Cedula\t\tNombre\t\t\t\tDireccion\t\tTelefono\tSalario");
            Console.WriteLine("========================================================================================================");
            Console.WriteLine($"{cedulaTemp}\t{nombreTemp}\t{direccionTemp}\t{telefonoTemp}\t{salarioTemp}");
            Console.WriteLine("========================================================================================================");
            Console.WriteLine("Desea almacenar la modificacion anterior? (Y/N)");
            almacenar = Convert.ToString(Console.ReadLine().ToLower());
            if (almacenar.Equals("y"))
            {
                int validar = Empleado.BuscarEmpleado(cedulaTemp);
                if (validar == -1 || pos == validar)
                {
                    Empleado.cedula[pos] = cedulaTemp;
                    Empleado.nombre[pos] = nombreTemp;
                    Empleado.direccion[pos] = direccionTemp;
                    Empleado.telefono[pos] = telefonoTemp;
                    Empleado.salario[pos] = salarioTemp;
                    Console.WriteLine("Los datos han sido almacenados en la base de datos.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("La cedula ingresada ya existe en otro registro.");
                    Console.WriteLine("Los datos no seran almacenados.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Los datos no seran almacenados.");
                Console.ReadLine();
            }
        }

        public void EliminarEmpleado(int ced)
        {
            int pos = Empleado.BuscarEmpleado(ced);
            if (pos == -1)
            {
                Console.WriteLine("No existe registro con el numero de cedula brindado.");
                Console.ReadLine();
            }
            string eliminar = "";
            if (pos != -1)
            {
                ConsultarEmpleado(ced);
                Console.WriteLine("Desea eliminar este registro? (Y/N)");
                eliminar = Convert.ToString(Console.ReadLine().ToLower());
                if (eliminar.Equals("y") & pos != -1)
                {
                    Empleado.cedula[pos] = 0;
                    Empleado.nombre[pos] = string.Empty;
                    Empleado.direccion[pos] = string.Empty;
                    Empleado.telefono[pos] = 0;
                    Empleado.salario[pos] = 0.0;
                    Console.WriteLine("Los datos han sido eliminados de la base de datos.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Los datos no seran eliminados.");
                    Console.ReadLine();
                }
            }
        }

        public void AvgSalario()
        {
            Console.WriteLine("\tPROMEDIO DE SALARIOS");
            Console.WriteLine("====================================");
            Console.WriteLine($"\t{Math.Round(Empleado.salario.Where(salario => salario != 0).Average(), 2)} colones");
            Console.WriteLine("====================================");
            Console.WriteLine("<PULSE CUALQUIER TECLA PARA CONTINUAR>");
            Console.ReadKey();
        }
        public void MinMaxSalario()
        {
            Console.WriteLine("\tEL SALARIO MINIMO ES: ");
            Console.WriteLine("====================================");
            Console.WriteLine($"\t   {Empleado.salario.Where(salario => salario != 0).Min()} colones");
            Console.WriteLine("====================================");
            Console.WriteLine(" ");
            Console.WriteLine("Los empleados con el salario minimo son:");
            Empleado.ExtraerDatosSalario(Empleado.salario.Where(salario => salario != 0).Min());
            Console.WriteLine(" ");
            Console.WriteLine("\tEL SALARIO MAXIMO ES: ");
            Console.WriteLine("====================================");
            Console.WriteLine($"\t   {Empleado.salario.Where(salario => salario != 0).Max()} colones");
            Console.WriteLine("====================================");
            Console.WriteLine(" ");
            Console.WriteLine("Los empleados con el salario maximo son:");
            Empleado.ExtraerDatosSalario(Empleado.salario.Where(salario => salario != 0).Max());
            Console.WriteLine("<PULSE CUALQUIER TECLA PARA CONTINUAR>");
            Console.ReadKey();
        }
    }
}
