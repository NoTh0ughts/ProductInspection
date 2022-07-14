using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class Factload
    {
        public Factload()
        {
            Factsources = new HashSet<Factsource>();
        }

        public int Idfactload { get; set; }
        public DateTime Dateload { get; set; }
        public DateTime Datetimefixed { get; set; }

        public virtual ICollection<Factsource> Factsources { get; set; }
    }
}
