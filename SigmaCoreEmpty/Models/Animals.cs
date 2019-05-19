using System;
using System.Collections.Generic;

namespace SigmaCoreEmpty.Models
{
    public partial class Animals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }
}
