using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entidades.db_Externa
{
    public class Access
    {
        [Key]
        public int Id { get; set; }
        public string? description { get; set; }
        public string? user_name { get; set; }
        public string? password { get; set; }
        public Boolean active { get; set; }
    }
}
