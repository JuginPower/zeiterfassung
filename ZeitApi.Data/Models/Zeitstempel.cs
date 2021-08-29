using System;
using System.Collections.Generic;

#nullable disable

namespace ZeitApi.Data.Models
{
    public partial class Zeitstempel
    {
        public long Personid { get; set; }
        public long? Arbeitbeginn { get; set; }
        public long? Pausenbeginn { get; set; }
        public long? Pausenende { get; set; }
        public long? Abstart { get; set; }
        public long? Abwesenheit { get; set; }
        public long? Arbeitende { get; set; }
        public byte[] Datum { get; set; }
    }
}
