using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Services.Models
{
    /// <summary>
    /// Модель данных для отображения
    /// </summary>
    public class ProductReport
    {
        public string Fullname { get;set; }
        public string KSSSUNIT { get; set; }
        public DateTime DateTime { get; set; }
    }
}
