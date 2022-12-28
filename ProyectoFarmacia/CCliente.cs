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
            int opcion = CMenu.ValidarEntero("Solo números entre 1 y 4", 1, 4);
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
                    Console.Write("Apellido nuevo: ");
                    s = Console.ReadLine();
                    Apellido = s;
                    break;
                case 4:
                    Console.Write("Direccion nueva: ");
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
                return (Nombre.ToUpper()).Contains(Text) || (Apellido.ToUpper()).Contains(Text) || Codigo.Contains(Text);
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
            Console.Write("Cuál es el cliente que desea modificar (puede ingresar código o nombre): ");
            string ElementToModify = Console.ReadLine();
            int Position = base.Ubicacion(ElementToModify.ToUpper());
            CNodoLista Node = (CNodoLista)Iesimo(Position, true);
            CCliente ProductoAModificar = (CCliente)Node.Element;
            ProductoAModificar.Modificar();
        }
        public void Buscar()
        {
            Console.Write("¿Qué cliente desea buscar?[Nombre, Apellido o código]: ");
            string ElementToSearch = Console.ReadLine();
            int posicion = Ubicacion(ElementToSearch.ToUpper());
            if (posicion != -1)
            {
                CNodoLista Node = (CNodoLista)Iesimo(posicion, true);
                CCliente Element = (CCliente)Node.Element;
                Console.WriteLine("--------------------CLIENTE--------------------");
                Element.Mostrar();
            }
            else
            {
                Console.WriteLine("No se encontró el cliente requerido");
            }
        }
    }
}
