using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class Lproduct
    {
        public Lproduct()
        {
            Factsources = new HashSet<Factsource>();
        }

        /// <summary>
        /// Справочник продуктов в кодах КССС
        /// </summary>
        public int Ksssprod { get; set; }
        public string Name { get; set; }
        public string Fullname { get; set; }
        public int? Idproductgroup { get; set; }
        public DateTime Dupdate { get; set; }
        public string Gost { get; set; }
        public string Okp { get; set; }
        public int? Ordernumber { get; set; }

        public virtual ICollection<Factsource> Factsources { get; set; }
    }
}
