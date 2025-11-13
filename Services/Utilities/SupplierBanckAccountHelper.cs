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
            // Normaliza a JArray
            JArray arr = results is JArray ja
                ? ja
                : results is JObject jo && jo["results"] is JArray ja2
                    ? ja2
                    : JArray.FromObject(results);

            return arr.ToObject<List<SupplierBanckAccount>>() ?? new List<SupplierBanckAccount>();
        }

        /// <summary>
        /// Variante defensiva por si algunos nombres vienen diferentes (ej. CSTATUS vs CCSTATUS).
        /// </summary>
        public static List<SupplierBanckAccount> ConvertToList(dynamic results)
        {
            JArray arr = results is JArray ja ? ja : JArray.FromObject(results);
            var list = new List<SupplierBanckAccount>();

            foreach (JObject it in arr)
            {
                list.Add(new SupplierBanckAccount
                {
                    CBANK_ACCOUNT_ID = it.Value<string>("CBANK_ACCOUNT_ID"),
                    CBANK_NAME = it.Value<string>("CBANK_NAME"),
                    CBANK_NAT_CODE = it.Value<string>("CBANK_NAT_CODE"),
                    CBP_UUID = it.Value<string>("CBP_UUID"),
                    TBP_UUID = it.Value<string>("TBP_UUID"),

                    // toma CSTATUS o CCSTATUS (si tu OData usa ese nombre)
                    CSTATUS = it.Value<string>("CSTATUS") ?? it.Value<string>("CCSTATUS"),
                    TSTATUS = it.Value<string>("TSTATUS"),

                    // Si es fecha y puede venir vacía, usa string o Nullable<DateTime>
                    CCREATION_DT = it.Value<string>("CCREATION_DT")
                });
            }
            return list;
        }
    }
}
