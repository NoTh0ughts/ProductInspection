using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class ConfigurationModel
    {
        public string Username { get; set;}
        public string Password { get; set;}
        public string InitialCatalog { get; set;}
        public string Server { get; set;}
        public bool TrustedConnection { get; set; }
    }

}
