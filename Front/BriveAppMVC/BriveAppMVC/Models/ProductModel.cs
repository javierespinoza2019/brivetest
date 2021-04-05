namespace BriveAppMVC.Models
{
	///<summary>
	///Informacion de productos
	///</summary>
	public class ProductModel
	{
		///<summary>
		///Identificador de producto
		///</summary>
		public long Id { get; set; }

		///<summary>
		///Nombre del producto
		///</summary>
		public string Name { get; set; }

		///<summary>
		///Precio unitario
		///</summary>
		public decimal UnitPrice { get; set; }

		///<summary>
		///Codigo de barras
		///</summary>
		public string Barcode { get; set; }
	}
}