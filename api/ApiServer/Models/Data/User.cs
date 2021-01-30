using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Models
{
    public class User : DataModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
