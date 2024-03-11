using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LoginInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string InfoId { get; set; }

        public string UserEmail { get; set; } = string.Empty;

        public string Ip { get; set; } = string.Empty;


        public string Os { get; set; } = string.Empty;

        public string Browser { get; set; } = string.Empty;

        

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? Intime { get; set; } = DateTime.UtcNow;

        public DateTime? OutTime { get; set; }
    }
}
