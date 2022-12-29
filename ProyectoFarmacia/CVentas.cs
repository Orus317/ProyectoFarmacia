namespace ProyectoFarmacia
{
    public class CVentas
    {
        private string? _Codigo_Venta;
        private string? _Codigo_Cliente;
        private string? Producto;
        private string? _Fecha;
        private int? _Monto;

        public string? Codigo_Venta { get => _Codigo_Venta; set => _Codigo_Venta = value; }
        public string? Codigo_Cliente { get => _Codigo_Cliente; set => _Codigo_Cliente = value; }
        public string? Lista_Productos { get => Producto; set => Producto = value; }
        public string? Fecha { get => _Fecha; set => _Fecha = value; }
        public int? Monto { get => _Monto; set => _Monto = value; }

        public CVentas(string codigo_Venta, string codigo_cliente, string? Producto, string fecha, int monto)
        {
            Codigo_Venta = codigo_Venta;
            Codigo_Cliente = codigo_cliente;
            Lista_Productos = Producto;
            Fecha = fecha;
            Monto = monto;
        }

        public void Monstrar()
        {
            Console.WriteLine("Venta: " + Codigo_Venta);
            Console.WriteLine("Cliente: " + Codigo_Cliente);
            Console.WriteLine("Productos: " + Lista_Productos);
            Console.WriteLine("Fecha: " + Fecha);
            Console.WriteLine("Monto: " + Monto);
            Console.WriteLine("---------------------------------");
        }

        public string fecha()
        {
            return Fecha;
        }

        public override string ToString()
        {
            if (Codigo_Venta != null)
            {
                return Codigo_Venta;
            }
            return "";
        }

        public override bool Equals(object? obj)
        {
            if (obj is CVentas Ventas)
            {
                return Ventas.Codigo_Venta == Codigo_Venta;
            }
            return false;
        }

    }

    public class CListaVentas : CListaEnlazada
    {
        public void IngresarVenta()
        {
            Console.Write("Ingrese el codigo de la venta: ");
            string codigo_venta = Console.ReadLine();
            Console.Write("Ingrese el codigo del cliente: ");
            string codigo_cliente = Console.ReadLine();
            Console.Write("Ingrese el código del producto: ");
            string Producto = Console.ReadLine();
            Console.Write("Ingrese la fecha de la venta: ");
            string fecha = Console.ReadLine();
            Console.Write("Ingrese el montode la venta: ");
            int monto = int.Parse(Console.ReadLine());
            CVentas Venta = new(codigo_venta, codigo_cliente, Producto, fecha, monto);
            Agregar(Venta);
            Venta.Monstrar();
        }

        public override void Listar()
        {
            CNodoLista? Aux = Node;
            for (int i = 0; i < Longitud(); i++)
            {
                Console.WriteLine("--------------------Venta {0}--------------------", i + 1);
                ((CVentas)Aux.Element).Monstrar();
                Aux = Aux.NextNode;
            }
        }
        public void ListarFecha()
        {
            Console.WriteLine("Ingrese una fecha");
            string fecha = Console.ReadLine();
            int a = 0;
            CNodoLista? Aux = Node;
            Console.WriteLine("------------Ventas {0}--------", fecha);
            for (int i = 0; i < Longitud(); i++)
            {
                if (((CVentas)Aux.Element).fecha() == fecha)
                {
                    a--;
                    ((CVentas)Aux.Element).Monstrar();
                }
                Aux = Aux.NextNode;
            }
            if (a == 0)
                Console.WriteLine("No hay ventas en {0}", fecha);
        }
    }
}


