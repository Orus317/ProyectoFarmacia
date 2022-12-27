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
        public static void MostrarMenu(CListaEnlazada Clientes, CListaEnlazada Productos, CListaEnlazada Ventas)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("1.- Agregar Producto");
            Console.WriteLine("2.- Buscar Producto");
            Console.WriteLine("3.- Eliminar producto");
            Console.WriteLine("4.- Modificar producto");
            Console.WriteLine("5.- Registrar Clientes ");
            Console.WriteLine("6.- Buscar Clientes");
            Console.WriteLine("7.- Registrar Ventas ");
            Console.WriteLine("8.- Mostrar reporte ventas diarias (reporte diario)");
            Console.WriteLine("9.- Visualizar Productos.");
            Console.WriteLine("10.- Visualizar Clientes.");

            Console.WriteLine(" -- Ingrese la opción: ");
            int Opcion = ValidarEntero("Debe ingresar un número, entre 1 y 10", 1, 10);
            EjecutarOpcion(Opcion, Clientes, Productos, Ventas);
        }
        private static void EjecutarOpcion(int opcion, CListaEnlazada Clientes, CListaEnlazada Productos, CListaEnlazada Ventas)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("--------");
                    Console.Write("Ingrese el codigo del producto: ");
                    string codigo = Console.ReadLine();
                    Console.Write("Ingrese nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la descripcción del producto");
                    string descripcion = Console.ReadLine();
                    Console.WriteLine("Ingrese la fecha de fabricación en formato dd/mm/yy: ");
                    DateTime fecha_fabricacion = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la fecha de vencimiento en formato dd/mm/yy: ");
                    DateTime fecha_vencimiento = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el proveedor: ");
                    string proveedor = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio: ");
                    float precio = int.Parse(Console.ReadLine());
                    CProducto producto_nuevo = new(codigo, nombre, descripcion, fecha_fabricacion, fecha_vencimiento, proveedor, precio);
                    Productos.Agregar(producto_nuevo);
                    Console.WriteLine("--------");
                    break;
                case 2:
                    Console.Write("Ingrese el codigo del producto: ");
                    codigo = Console.ReadLine();
                    break;
                case 3:    
                    Console.Write("Ingrese el codigo del producto: ");
                    codigo = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Ingrese el codigo del producto: ");
                    codigo = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Ingrese el codigo del cliente: ");
                    string codigo_cliente = Console.ReadLine();
                    Console.Write("Ingrese el nombre del cliente: ");
                    string nombre_cliente = Console.ReadLine(); ;
                    Console.Write("Ingrese los apellidos del cliente: ");
                    string apellido_ciente = Console.ReadLine();
                    Console.Write("Ingrese el la dirección del cliente: ");
                    string direccion = Console.ReadLine();
                    CCliente cliente_nuevo = new(codigo_cliente, nombre_cliente, apellido_ciente, direccion);
                    Clientes.Agregar(cliente_nuevo);
                    Console.WriteLine("--------");
                    break;
                case 6:
                    Console.Write("Ingrese el codigo del cliente: ");
                    codigo_cliente = Console.ReadLine();
                    break;
                case 7:
                    Console.Write("Ingrese el codigo de la venta: ");
                    string codigo_venta;
                    Console.Write("Ingrese el codigo del cliente: ");
                    codigo_cliente = Console.ReadLine();
                    Console.Write("Ingrese el codigo del producto: ");
                    // ListaEnlazada lista_productos = new();
                    Console.Write("Ingrese la fecha de la veta: ");
                    string fecha;
                    Console.Write("Ingrese el montode la venta: ");
                    int monto;

                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                default:
                    break;

    }
}
    }
}

