using Newtonsoft.Json.Linq;
using Repository.Entidades.Odatas;

namespace Services.Utilities
{
    public class SupplierBanckAccountHelper
    {
        /// <summary>
        /// Recibe el "results" de SAP (dynamic/JArray/JObject) y lo convierte a List<SupplierBanckAccount>.
        /// Acepta strings vacíos sin fallar (las props del DTO son string/nullable).
        /// </summary>
        public static List<SupplierBanckAccount> ToList(dynamic results)
        {
            JArray arr = results is JArray ja
                ? ja
                : results is JObject jo && jo["results"] is JArray ja2
                    ? ja2
                    : JArray.FromObject(results);

            return arr.ToObject<List<SupplierBanckAccount>>() ?? new List<SupplierBanckAccount>();
        }
    }
}
