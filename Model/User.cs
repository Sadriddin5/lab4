using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApi.Model
{
    public class User
    {
        public long IdUser { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
