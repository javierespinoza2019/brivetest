namespace Brive.Inventory.Entities
{
    /// <summary>
    /// Informacion del paginado
    /// </summary>
    public class PagerModel
    {
        /// <summary>
        /// Registros por pagina
        /// </summary>
        public int RecordsPerPage { get; set; } = 10;
        /// <summary>
        /// Numero de pagina actual
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Total de registros en base de datos
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// indica si se retorna todos los registros
        /// </summary>
        public bool ReturnAll { get; set; }
    }
}
