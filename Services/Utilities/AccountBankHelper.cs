using Newtonsoft.Json.Linq;
using Repository.Entidades.db;

namespace Services.Utilities
{
    public class AccountBankHelper
    {
        public static List<sap_maestro_cuentas_bancarias> ToList(dynamic results)
        {
            JArray arr = results is JArray ja
                ? ja
                : results is JObject jo && jo["results"] is JArray ja2
                    ? ja2
                    : JArray.FromObject(results);

            return arr.ToObject<List<sap_maestro_cuentas_bancarias>>() ?? new List<sap_maestro_cuentas_bancarias>();
        }
    }
}
