using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class Factsource
    {
        public int Idfactsource { get; set; }
        public int Idfactload { get; set; }
        public int Ksssprod { get; set; }
        public int Ksssunit { get; set; }
        public decimal? Vreceipt { get; set; }

        public virtual Factload IdfactloadNavigation { get; set; }
        public virtual Lproduct KsssprodNavigation { get; set; }
    }
}
