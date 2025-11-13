using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entidades.db_Externa
{
    public class Task
    {
        public int Id { get; set; }
        public string? description { get; set; }
        public int company_id { get; set; }
        //   public virtual Company? Company { get; set; }
        public int user_id { get; set; }
        [ForeignKey(nameof(user_id))]
        public virtual Access? user { get; set; }
        public int odata_link_id { get; set; }
        [ForeignKey(nameof(odata_link_id))]
        public virtual ODataLink? link { get; set; }
        public string? frequency { get; set; }
        public int minute_range { get; set; }
        public bool enable { get; set; }
        public bool active { get; set; }
    }
}
