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
            return false;
        }
        // ----------------------------------------------------------------------------------
    }
}
