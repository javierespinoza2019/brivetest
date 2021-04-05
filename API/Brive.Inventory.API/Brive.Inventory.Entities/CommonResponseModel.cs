namespace Brive.Inventory.Entities
{
    public class CommonResponseModel
    {
        /// <summary>
        /// Estatus de la respuesta
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Identificador afectado
        /// </summary>
        public long IdAfected { get; set; }
    }
}