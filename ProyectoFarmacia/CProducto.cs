namespace ProyectoFarmacia
{
    public class CProducto
    {
        #region Atributos / Propiedades / Campos
        private string? _Codigo;
        private string? _Nombre;
        private string? _Descripcion;
        private DateTime? _FechaFabricacion;
        private DateTime? _FechaVencimiento;
        private string? _Proveedor;
        private float? _Precio;
        public string? Codigo { get => _Codigo; set => _Codigo = value; }
        public string? Nombre { get => _Nombre; set => _Nombre = value; }
        public string? Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public DateTime? FechaFabricacion { get => _FechaFabricacion; set => _FechaFabricacion = value; }
        public DateTime? FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }
        public string? Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public float? Precio { get => _Precio; set => _Precio = value; }
        #endregion
        #region Constructor
        public CProducto(string codigo, string nombre, string descripcion, DateTime fechaFabricacion, DateTime fechaVencimiento, string proveedor, float precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaFabricacion = fechaFabricacion;
            FechaVencimiento = fechaVencimiento;
            Proveedor = proveedor;
            Precio = precio;
        }
        #endregion
        #region Metodos
        public void Modificar()
        {
            string s;
            float i;
            DateTime d;
            Console.WriteLine("-------MENU DE MODIFICACION-------");
            Mostrar();
            Console.Write("Que desea modificar: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Write("Código nuevo: ");
                    s = Console.ReadLine();
                    Codigo = s;
                    break;
                case 2:
                    Console.Write("Nombre nuevo: ");
                    s = Console.ReadLine();
                    Nombre = s;
                    break;
                case 3:
                    Console.Write("Descripción nueva: ");
                    s = Console.ReadLine();
                    Descripcion = s;
                    break;
                case 4:
                    Console.Write("Fecha de fabricacion nueva (formato dd/mm/año): ");
                    d = DateTime.Parse(Console.ReadLine());
                    FechaFabricacion = d;
                    break;
                case 5:
                    Console.Write("Fecha de vencimiento nueva (formato dd/mm/año): ");
                    d = DateTime.Parse(Console.ReadLine());
                    FechaVencimiento = d;
                    break;
                case 6:
                    Console.Write("Proveedor nuevo: ");
                    s = Console.ReadLine();
                    Proveedor = s;
                    break;
                case 7:
                    Console.Write("Precio nuevo: ");
                    i = float.Parse(Console.ReadLine());
                    Precio = i;
                    break;
                default:
                    break;
            }
            Console.WriteLine("----------------------------------");
        }
        public void Mostrar()
        {
            Console.WriteLine("1. Codigo: " + Codigo);
            Console.WriteLine("2. Nombre: " + Nombre);
            Console.WriteLine("3. Descripcion: " + Descripcion);
            Console.WriteLine("4. Fecha de Fabricacion: " + FechaFabricacion);
            Console.WriteLine("5. Fecha de vencimiento: " + FechaVencimiento);
            Console.WriteLine("6. Proveedor: " + Proveedor);
            Console.WriteLine("7. Precio: S/." + Precio );
        }
        // --Ambos métodos se centran en la comparación del código identificador del objeto--
        public override string ToString()
        {
            if (Codigo != null)
            {
                return Codigo;
            }
            return "";
        }
        public override bool Equals(object? obj)
        {
            if (obj is CProducto Product)
            {
                return Product.Codigo == Codigo;
            }
            else if (obj is string ProductName && Nombre != null)
            {
                return Nombre.Contains(ProductName);
            }
            return false;
        }
        // ----------------------------------------------------------------------------------
        #endregion
    }
    public class CListaProductos : CListaEnlazada
    {
        public void AgregarProducto()
        {
            Console.Write("1. Codigo: ");
            string _Codigo = Console.ReadLine();
            Console.Write("2. Nombre: ");
            string _Nombre = Console.ReadLine();
            Console.Write("3. Descripcion: ");
            string _Descripcion = Console.ReadLine();
            Console.Write("4. Fecha de Fabricacion (en formato dd/mm/yy): ");
            DateTime _FechaFabricacion = DateTime.Parse(Console.ReadLine());
            Console.Write("5. Fecha de vencimiento (en formato dd/mm/yy): ");
            DateTime _FechaVencimiento = DateTime.Parse(Console.ReadLine());
            Console.Write("6. Proveedor: ");
            string _Proveedor = Console.ReadLine();
            Console.Write("7. Precio (S/.): ");
            float _Precio = CMenu.ValidarFlotante("Números mayores a 0", 0, float.PositiveInfinity);
            CProducto _ = new(_Codigo, _Nombre, _Descripcion, _FechaFabricacion, _FechaVencimiento, _Proveedor, _Precio);
            Agregar(_);
            Console.WriteLine("======================PRODUCTO AÑADIDO======================");
            _.Mostrar();
        }
        public override void Listar()
        {
            CNodoLista? Aux = Node;
            for (int i = 0; i < Longitud(); i++)
            {
                Console.WriteLine("--------------------PRODUCTO {0}--------------------", i+1);
                ((CProducto)Aux.Element).Mostrar();
                Aux = Aux.NextNode;
            }
        }
        public void Modificar()
        {
            int Longitud = base.Longitud();
            Console.Write("Cuál es el elemento que desea modificar de los {0} elementos: ", Longitud);
            int Position = int.Parse(Console.ReadLine()) - 1;
            CProducto ProductoAModificar = (CProducto)((CNodoLista)Iesimo(Position)).Element;
            ProductoAModificar.Modificar();
        }
        public void Buscar(string Element)
        {
            Console.WriteLine("¿Qué producto desea buscar?[Puede ingresar código o nombre]: ");
            int posicion = Ubicacion(Element.ToUpper());
            if (posicion != -1)
            {
                CProducto _ = (CProducto)Iesimo(posicion, true);
                Console.WriteLine("--------------------PRODUCTO--------------------");
                _.Mostrar();
            }
            else
            {
                Console.WriteLine("No se encontró el producto requerido");
            }
        }
    }
}
