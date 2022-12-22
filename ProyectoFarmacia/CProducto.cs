namespace ProyectoFarmacia
{
    public class CProducto
    {
        #region Atributos / Propiedades / Campos
        private string _Codigo;
        private string _CodigoCliente;
        private string _Descripcion;
        private string _FechaFabricacion;
        private string _FechaVencimiento;
        private string _Proveedor;
        private float _Precio;
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string CodigoCliente { get => _CodigoCliente; set => _CodigoCliente = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string FechaFabricacion { get => _FechaFabricacion; set => _FechaFabricacion = value; }
        public string FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }
        public string Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public float Precio { get => _Precio; set => _Precio = value; }
        #endregion
        #region Constructor
        public CProducto(string codigo, string codigoCliente, string descripcion, string fechaFabricacion, string fechaVencimiento, string proveedor, float precio)
        {
            Codigo = codigo;
            CodigoCliente = codigoCliente;
            Descripcion = descripcion;
            FechaFabricacion = fechaFabricacion;
            FechaVencimiento = fechaVencimiento;
            Proveedor = proveedor;
            Precio = precio;
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
            if (obj is CProducto Product)
            {
                return Product.Codigo == Codigo;
            }
            return false;
        }
        // ----------------------------------------------------------------------------------
    }
}
