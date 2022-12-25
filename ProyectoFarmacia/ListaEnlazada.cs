namespace ProyectoFarmacia
{
    public interface ILista
    {
        /// <summary>
        /// Método para determinar si un nodo/elemento de la lista es vacío
        /// </summary>
        /// <returns>True or False</returns>
        bool EsVacia();
        /// <summary>
        /// Método para calcular la cantidad de elementos que existen en una lista
        /// </summary>
        /// <returns>Un valor entero</returns>
        int Longitud();
        /// <summary>
        /// Método para agregar un elemento a la lista (al final)
        /// </summary>
        void Agregar(object Element);
        /// <summary>
        /// Método para insertar un elemento en una posición determinada
        /// </summary>
        /// <param name="Element">Elemento a colocar</param>
        /// <param name="Position">Posición en la que colocar</param>
        void Insertar(object Element, int Position);
        /// <summary>
        /// Retornar el elemento de la posición "Position"
        /// </summary>
        /// <param name="Position">Posición solicitada</param>
        /// <returns></returns>
        object Iesimo(int Position);
        /// <summary>
        /// Método para buscar un elemento
        /// </summary>
        /// <param name="Element">Elemento a ser buscado</param>
        /// <returns></returns>
        int Ubicacion(object Element);
        /// <summary>
        /// Elimina un elemento de la lista
        /// </summary>
        /// <param name="Position">Elemento a eliminar</param>
        void Eliminar(int Position);
        /// <summary>
        /// Lista todos los elementos
        /// </summary>
        void Listar();
    }
    public class CNodoLista
    {
        #region Atributos y Propiedades/Campos
        private Object? _element;
        private CNodoLista? _nextNode;
        public object? Element { get => _element; set => _element = value; }
        public CNodoLista? NextNode { get => _nextNode; set => _nextNode = value; }
        #endregion
        #region Constructores
        public CNodoLista()
        {
            Element = null;
            NextNode = null;
        }
        public CNodoLista(object? element)
        {
            Element = element;
            NextNode = null;
        }
        public CNodoLista(object? element, CNodoLista? nextNode) : this(element)
        {
            NextNode = nextNode;
        }
        public void Mostrar()
        {
            Console.WriteLine("============================");
            if (Element == null)
            {
                Console.Write("Elemento nulo.");
            }
            else
            {
                Console.WriteLine(Element.ToString());
            }
            if (NextNode == null)
            {
                Console.WriteLine("Sig nodo nulo");
            }
            else
            {
                Console.WriteLine(NextNode.ToString());
            }
            Console.WriteLine("============================");
        }
        #endregion
    }
    public class CListaEnlazada : ILista
    {
        #region Atributos y propiedades
        private CNodoLista? _node;
        public CNodoLista? Node { get => _node; set => _node = value; }
        #endregion
        #region Constructores
        public CListaEnlazada()
        {
            // Esta es la creación de un nodo vacío
            Node = new();
        }
        public CListaEnlazada(CNodoLista? node)
        {
            // Acá es cuando anclas un nuevo nodo
            Node = node;
        }

        #endregion
        #region Methods
        public void Agregar(object Element)
        {
            if (EsVacia())
            {
                Node.Element = Element;
            }
            else
            {
                CNodoLista Aux = Node;
                while (Aux.NextNode != null)
                {
                    Aux = Aux.NextNode;
                }
                Aux.NextNode = new CNodoLista(Element);
            }
        }
        public void Eliminar(int Position)
        {
            // Evadir el caso en el que se intenta eliminar el último nodo, el nodo nulo
            if (Position < Longitud())
            {
                // Encontrando el elemento previo al que se va a eliminar
                object NodeBeforeTheOneToEliminate = Iesimo(Position - 1, true);
                // Verificando posición y mutando para ahorrar líneas 
                if (NodeBeforeTheOneToEliminate != null && NodeBeforeTheOneToEliminate is CNodoLista NodeBefore)
                {
                    // Eliminando el nodo
                    NodeBefore.NextNode = NodeBefore.NextNode.NextNode;
                }
                else
                {
                    // Indicando si el nodo estuvo fuera de posición
                    Console.WriteLine("Fuera de alcance");
                }
            }
            // Cuando se quiere eliminar el nodo nulo
            else
            {
                Console.WriteLine("Fuera de alcance");
            }
        }
        public void Eliminar(object Element)
        {
            int Position = Ubicacion(Element);
            // Validar la existencia del elemento
            if (Position != -1)
            {
                // Eliminando por posición
                Eliminar(Position);
            }
            else
            {
                Console.WriteLine("No existe dicho elemento en la lista");
            }
        }
        public bool EsVacia()
        {
            return Node.Element == null && Node.NextNode == null;
        }
        public object Iesimo(int Position)
        {
            return Iesimo(Position, false);
        }
        public object Iesimo(int Position, bool returnObject = false)
        {
            // Flag -> Si es verdadera retornará el objeto itself, no solo el elemento
            if (Position < Longitud() && Position >= 0)
            {
                CNodoLista Aux = Node;
                for (int i = 0; i < Position; i++)
                {
                    Aux = Aux.NextNode;
                }
                return returnObject ? Aux : Aux.Element;
            }
            return null;
        }
        public void Insertar(object Element, int Position)
        {
            if (Position < Longitud() || Position == 0)
            {
                CNodoLista? Aux = Node;
                for (int i = 0; i < Position; i++)
                {
                    Aux = Aux.NextNode;
                }
                object AuxElement = Aux.Element;
                Aux.Element = Element;
                Aux.NextNode = new(AuxElement, Aux.NextNode);
            }
        }
        public void Listar()
        {
            CNodoLista? Aux = Node;
            for (int i = 0; i < Longitud(); i++)
            {
                Console.Write(Aux.Element.ToString() + ", ");
                Aux = Aux.NextNode;
            }
            Console.WriteLine();
        }
        public int Longitud()
        {
            int k = 1;
            CNodoLista? Aux = Node.NextNode;
            while (Aux != null)
            {
                Aux = Aux.NextNode;
                k++;
            }
            return k;
        }
        public int Ubicacion(object Element)
        {
            CNodoLista CurrentNode = Node;
            int i = 0;
            //while (CurrentNode != null && CurrentNode.Element != Element)
            while (CurrentNode != null && !CurrentNode.Element.Equals(Element))
            {
                i++;
                CurrentNode = CurrentNode.NextNode;
            }
            return CurrentNode == null ? -1 : i;
        }
        #endregion
    }
}
