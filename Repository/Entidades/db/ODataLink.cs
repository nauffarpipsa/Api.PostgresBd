using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entidades.db_Externa
{
    public class ODataLink
    {
        [Key]
        public int id { get; set; }
        public string? description { get; set; }
        public string? link { get; set; }
        public string? body { get; set; }
        public Boolean active { get; set; }
    }
}
