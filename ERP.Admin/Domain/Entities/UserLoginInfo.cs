using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserLoginInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string InfoId { get; set; }
        public string UserId { get; set; }

        public string Ip { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public DateTime Intime { get; set; } = DateTime.UtcNow;

        public DateTime? OutTime { get; set; }
    }
}
