namespace Brive.Inventory.Entities
{
	using System;
    using System.Data.SqlTypes;

    ///<summary>
    ///Identificador de transaccion de inventario
    ///</summary>
    public class InventoryModel
	{
		///<summary>
		///Identificador de transaccion de inventario
		///</summary>
		public long Id { get; set; }

		///<summary>
		///Identificador de la sucursal
		///</summary>
		public int StoreId { get; set; }

		///<summary>
		///Fecha de la transaccion
		///</summary>
		public DateTime TransactionDate { get; set; } = (DateTime)SqlDateTime.MinValue;

		///<summary>
		///Codigo de barras
		///</summary>
		public string Barcode { get; set; }

		///<summary>
		///Nombre del producto
		///</summary>
		public string ProductName { get; set; }

		///<summary>
		///Cantidad de productos
		///</summary>
		public int Quantity { get; set; }
	}
}
