using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Services.Models
{
    /// <summary>
    /// Data - класс, для передачи конфига подключения к бд
    /// </summary>
    public class DatabaseConfigurationModel
    {
        public string InitialCatalog { get; set; }
        public string DataSource { get; set; }
        public bool IntegratedSecurity { get; set; }

        public string AsConnectionString()
        {
            return $"Data Source={DataSource};Initial Catalog={InitialCatalog};Integrated Security={IntegratedSecurity}";
        }
    }
}
