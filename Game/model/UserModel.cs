using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class UserModel
    {
        public int id { get; set; }
        public string qr_code { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string system_code { get; set; }
        public int created { get; set; }

    }
}
