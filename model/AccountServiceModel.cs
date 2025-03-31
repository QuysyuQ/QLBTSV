using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AccountServiceModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roll { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DateCreate { get; set; } = DateTime.Now;
    }

}
