namespace Brive.Inventory.Framework.Common.Utilities
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Dynamic;

    /// <summary>
    /// Utilidades
    /// </summary>
    public static class Utilities
    {
        public static object ToJSON(this IDataReader reader)
        {
            string json = string.Empty;

            if (reader == null) return json;

            while (reader.Read())
            {
                json += reader.GetString(0);
            }
            return json;
        }
        /// <summary>
        /// Serializa una cadena JSON a Objecto .Net nativo (object) en formato camelCase
        /// </summary>
        /// <param name="json">Cadena json a convertir</param>
        /// <param name="isRootArray">Indica si el json es un array o un objeto</param>
        /// <returns></returns>
        public static object ToCamelCase(this object json, bool isRootArray = false)
        {
            string jsonCamelCase = string.Empty;
            if (string.IsNullOrWhiteSpace(json.ToString())) return string.IsNullOrWhiteSpace(jsonCamelCase) ? (isRootArray ? "[]" : "{}") : jsonCamelCase;
            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                IEnumerable<ExpandoObject> interimObjectList = null;
                ExpandoObject interimObject = null;

                if (isRootArray)
                {
                    interimObjectList = JsonConvert.DeserializeObject<IEnumerable<ExpandoObject>>(json.ToString());
                    jsonCamelCase = JsonConvert.SerializeObject(interimObjectList, jsonSerializerSettings);
                }
                else
                {
                    interimObject = JsonConvert.DeserializeObject<ExpandoObject>(json.ToString());
                    jsonCamelCase = JsonConvert.SerializeObject(interimObject, jsonSerializerSettings);
                }

            }
            catch (Exception error)
            {
            }
            return string.IsNullOrWhiteSpace(jsonCamelCase) ? (isRootArray ? "[]" : "{}") : jsonCamelCase;
        }
    }
}
