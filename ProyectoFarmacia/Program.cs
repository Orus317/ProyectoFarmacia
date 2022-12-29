using System.Text;
using ProyectoFarmacia;

// Creando lista de productos
CListaProductos Productos = new();
CListaClientes Clientes = new();
CListaVentas Ventas = new();

// Lector del archivo csv para generar la lista CLisaProductos
using (StreamReader reader = new(@".\farmacia.csv", Encoding.GetEncoding("iso-8859-1")))
{
	// Omitir la primera línea
	reader.ReadLine();
	// Leer todas las líneas del archivo 
	while (!reader.EndOfStream)
	{
		string codigo, nombre, descripcion, proveedor;
		DateTime fechaFabricacion, fechaVencimiento;
		float precio;
		// Leyendo la linea
		string? line = reader.ReadLine();
		// Separando valores por ";"
		string[] values = line.Split(";");
		// Asignaciones
		codigo = values[0];
		nombre = values[1];
		descripcion = values[2];
		fechaFabricacion = DateTime.Parse(values[3]);
		fechaVencimiento = DateTime.Parse(values[4]);
		proveedor = values[5];
		precio = float.Parse(values[6]);
		//Agregar el producto a la lista de productos
		Productos.Agregar(new CProducto(codigo, nombre, descripcion, fechaFabricacion, fechaVencimiento, proveedor, precio));
	}
}

// Lista de clientes
Clientes.Agregar(new CCliente("95961212", "Elías", "Vicente Carballo", "3467 Tawny Terrace"));
Clientes.Agregar(new CCliente("36192134", "Marcos", "Gras Lastra", "837 Middle Diversion"));
Clientes.Agregar(new CCliente("85586251", "Marcial", " Rivero Grau", "4430 Quaking Anchor Ramp"));
Clientes.Agregar(new CCliente("85143178", "Jose", " Francisco Jáuregui Cortés", "6913 Golden Cider Park"));
Clientes.Agregar(new CCliente("45686143", "Ofelia", " Zabaleta Miralles", "7712 Jagged Pine Passage"));
Clientes.Agregar(new CCliente("82784817", "África", " Soledad Ruiz Piñol", "3302 Colonial Dale Meadow"));
Clientes.Agregar(new CCliente("01278535", "Erasmo", " Mauricio Ortuño Ordóñez", "8773 Clear View"));
Clientes.Agregar(new CCliente("34480959", "Cristian", " Herrero Puente", "9306 Amber Inlet"));
Clientes.Agregar(new CCliente("05196068", "Eustaquio", " Yáñez-Ballesteros", "750 Cotton Highway"));
Clientes.Agregar(new CCliente("97218107", "Joaquina", " Milagros Zamora Saez", "3775 Cinder Autoroute"));

// Lista de Ventas

Ventas.Agregar(new CVentas("91035","95961212","101000801","12/05/2022",11));
Ventas.Agregar(new CVentas("92036","36192134","101001101","12/04/2022",2));
Ventas.Agregar(new CVentas("93036","85586251","101001601","11/04/2022",7));
Ventas.Agregar(new CVentas("94036","85143178","101001801","10/04/2022",11));
Ventas.Agregar(new CVentas("95036","45686143","101002001","11/03/2022",9));
Ventas.Agregar(new CVentas("96036","82784817","101002101","11/03/2022",14));
Ventas.Agregar(new CVentas("97036","01278535","101002301","12/04/2022",15));
Ventas.Agregar(new CVentas("98036","34480959","101002401","12/05/2022",8));
Ventas.Agregar(new CVentas("99036","05196068","101002601","10/05/2022",13));
Ventas.Agregar(new CVentas("81736","97218107","101003001","12/05/2022",15));

while (true)
{
	CMenu.MostrarMenu(Clientes, Productos, Ventas);
}

