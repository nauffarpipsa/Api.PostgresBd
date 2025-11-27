using Newtonsoft.Json.Linq;
using Repository.Entidades.db;

namespace BankHelper
{
    public class BankHelper
    {
        public static List<Bank> ToList(dynamic results)
        {
            JArray arr = results is JArray ja
                ? ja
                : results is JObject jo && jo["results"] is JArray ja2
                    ? ja2
                    : JArray.FromObject(results);

            return arr.ToObject<List<Bank>>() ?? new List<Bank>();
        }
    }

}
