namespace ProyectoFarmacia
{
    public class CVentas{
        private string? _Codigo_Venta;
        private string? _Codigo_Cliente;
        private CListaEnlazada? _Lista_Productos;
        private string? _Fecha;
        private int? _Monto;

        public string Codigo_Venta { get => _Codigo_Venta; set => _Codigo_Venta = value; }
        public string Codigo_Cliente { get => _Codigo_Cliente; set => _Codigo_Cliente = value; }
        public CListaEnlazada Lista_Productos { get => _Lista_Productos; set => _Lista_Productos = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public int? Monto { get => _Monto; set => _Monto = value; }

        public CVentas(string codigo_Venta, string codigo_cliente, CListaEnlazada lista_Productos, string fecha, int monto)
        {
            Codigo_Venta = codigo_Venta;
            Codigo_Cliente = codigo_cliente;
            Lista_Productos = lista_Productos;
            Fecha = fecha;
            Monto = monto;
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
}
