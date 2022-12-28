namespace ProyectoFarmacia
{
    public class CCliente
    {
        #region Atributos / Metodos / Campos
        private string? _Codigo;
        private string? _Nombre;
        private string? _Apellido;
        private string? _Direccion;
        public string? Codigo { get => _Codigo; set => _Codigo = value; }
        public string? Nombre { get => _Nombre; set => _Nombre = value; }
        public string? Apellido { get => _Apellido; set => _Apellido = value; }
        public string? Direccion { get => _Direccion; set => _Direccion = value; }
        #endregion
        #region Constructor
        public CCliente(string codigo, string nombre, string apellido, string direccion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
        }
        #endregion
        public void Mostrar()
        {
            Console.WriteLine("1. Codigo: " + Codigo);
            Console.WriteLine("2. Nombre: " + Nombre);
            Console.WriteLine("3. Apellido: " + Apellido);
            Console.WriteLine("4. Direccion: " + Direccion);
        }
        public void Modificar()
        {
            string s;
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
                    Console.Write("Apellido nueva: ");
                    s = Console.ReadLine();
                    Apellido = s;
                    break;
                case 4:
                    Console.Write("Direccion: ");
                    s = Console.ReadLine();
                    Direccion = s;
                    break;
                default:
                    break;
            }
            Console.WriteLine("----------------------------------");
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
            if (obj is CCliente Client)
            {
                return Client.Codigo == Codigo;
            }
            else if (obj is string Text)
            {
                return Nombre.Contains(Text) || Apellido.Contains(Text);
            }
            return false;
        }
        // ----------------------------------------------------------------------------------
    }
    public class CListaClientes : CListaEnlazada
    {
        public void AgregarCliente()
        {
            Console.Write("1. Codigo: ");
            string _Codigo = Console.ReadLine();
            Console.Write("2. Nombre: ");
            string _Nombre = Console.ReadLine();
            Console.Write("3. Apellido: ");
            string _Apellido = Console.ReadLine();
            Console.Write("4. Direccion: ");
            string _Direccion = Console.ReadLine();
            CCliente _ = new(_Codigo, _Nombre, _Apellido, _Direccion);
            Agregar(_);
            Console.WriteLine("======================CLIENTE AÑADIDO======================");
            _.Mostrar();
        }
        public override void Listar()
        {
            CNodoLista? Aux = Node;
            for (int i = 0; i < Longitud(); i++)
            {
                Console.WriteLine("--------------------CLIENTE {0}--------------------", i + 1);
                ((CCliente)Aux.Element).Mostrar();
                Aux = Aux.NextNode;
            }
        }
        public void Modificar()
        {
            int Longitud = base.Longitud();
            Console.Write("Cuál es el cliente que desea modificar de los {0} elementos: ", Longitud);
            int Position = CMenu.ValidarEntero("Existen " + Longitud.ToString() + " clientes",0, Longitud + 1);
            CCliente ClienteAModificar = (CCliente)((CNodoLista)Iesimo(Position)).Element;
            ClienteAModificar.Modificar();
        }
        public void Buscar(string Element)
        {
            Console.WriteLine("¿Qué cliente desea buscar?: ");
            int posicion = Ubicacion(Element.ToUpper());
            if (posicion != -1)
            {
                CProducto _ = (CProducto)Iesimo(posicion, true);
                Console.WriteLine("--------------------PRODUCTO--------------------");
                _.Mostrar();
            }
            else
            {
                Console.WriteLine("No se encontró el cliente requerido");
            }
        }
    }
}
