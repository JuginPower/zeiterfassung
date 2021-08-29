using System;
using System.Collections.Generic;

#nullable disable

namespace ZeitApi.Data.Models
{
    public partial class Arbeiter
    {
        public long Personid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
