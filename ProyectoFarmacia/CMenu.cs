using System;
using System.Collections;

namespace ProyectoFarmacia
{
    public class CMenu
    {
        public static int ValidarEntero(string message, int low, int high)
        {
            // Modulo para validar un entero entre dos límites
            string _opcion = Console.ReadLine();
            int opcion = 0;
            // Usar una estructura try-catch para poder poder manejar errores de tipo, generalmente cuando
            // se ingresan letras u otros caracteres 
            try
            {
                // Intentar parsear el string ingresado
                opcion = int.Parse(_opcion);
                // si el string es parseado se verifica que esté entre los límites
                while (opcion > high || opcion < low)
                {
                    // mostrar el mensaje de warning en consola
                    Console.WriteLine(message);
                    // recibir nuevamente la opcion
                    _opcion = Console.ReadLine();
                    // intentar parsear
                    opcion = int.Parse(_opcion);
                }
            }
            catch (Exception)
            {
                // En caso de que el parseo no funcione inmediatamente se mostrará el warn message y se ejecutará el validador nuevamente
                Console.WriteLine(message);
                ValidarEntero(message, low, high);
            }
            return opcion;
        }
        public static float ValidarFlotante(string message, float low, float high)
        {
            // Modulo para validar un entero entre dos límites
            string _opcion = Console.ReadLine();
            float opcion = 0;
            // Usar una estructura try-catch para poder poder manejar errores de tipo, generalmente cuando
            // se ingresan letras u otros caracteres 
            try
            {
                // Intentar parsear el string ingresado
                opcion = float.Parse(_opcion);
                // si el string es parseado se verifica que esté entre los límites
                while (opcion > high || opcion < low)
                {
                    // mostrar el mensaje de warning en consola
                    Console.WriteLine(message);
                    // recibir nuevamente la opcion
                    _opcion = Console.ReadLine();
                    // intentar parsear
                    opcion = float.Parse(_opcion);
                }
            }
            catch (Exception)
            {
                // En caso de que el parseo no funcione inmediatamente se mostrará el warn message y se ejecutará el validador nuevamente
                Console.WriteLine(message);
                ValidarFlotante(message, low, high);
            }
            return opcion;
        }
        public static void MostrarMenu(CListaClientes Clientes, CListaProductos Productos, CListaVentas Ventas)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("1.- Agregar Producto");
            Console.WriteLine("2.- Buscar Producto");
            Console.WriteLine("3.- Eliminar producto");
            Console.WriteLine("4.- Modificar producto");
            Console.WriteLine("5.- Registrar Cliente");
            Console.WriteLine("6.- Buscar Cliente");
            Console.WriteLine("7.- Modificar Cliente");
            Console.WriteLine("8.- Registrar Ventas ");
            Console.WriteLine("9.- Visualizar todas las ventas ");
            Console.WriteLine("10.- Mostrar reporte ventas diarias (reporte diario)");
            Console.WriteLine("11.- Visualizar Productos.");
            Console.WriteLine("12.- Visualizar Clientes.");

            Console.Write(" -- Ingrese la opción: ");
            int Opcion = ValidarEntero("Debe ingresar un número, entre 1 y 12", 1, 12);
            EjecutarOpcion(Opcion, Clientes, Productos, Ventas);
        }
        private static void EjecutarOpcion(int opcion, CListaClientes Clientes, CListaProductos Productos, CListaVentas Ventas)
        {
            switch (opcion)
            {
                case 1:
                    Productos.AgregarProducto();
                    break;
                case 2:
                    Productos.BuscarProducto();
                    break;
                case 3:
                    Productos.EliminarProducto();
                    break;
                case 4:
                    Productos.Modificar();
                    break;
                case 5:
                    Clientes.AgregarCliente();
                    break;
                case 6:
                    Clientes.Buscar();
                    break;
                case 7:
                    Clientes.Modificar();
                    break;
                case 8:
                    Ventas.IngresarVenta();
                    break;
                case 9:
                    Ventas.Listar();
                    break;
                case 10:
                    Ventas.ListarFecha();
                    break;
                case 11:
                    Productos.Listar();
                    break;
                case 12:
                    Clientes.Listar();
                    break;
                default:
                    break;

    }
}
    }
}

