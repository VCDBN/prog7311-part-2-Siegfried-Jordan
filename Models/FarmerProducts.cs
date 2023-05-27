using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Jordan_Green._st10083222._PROG7311._POE._Part_2.Models
{
    public partial class FarmerProducts
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string TypeOfProduct { get; set; }
        public string ProductName { get; set; }
    }
}
