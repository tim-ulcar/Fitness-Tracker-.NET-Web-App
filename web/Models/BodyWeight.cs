using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class BodyWeight
    {
        public int bodyWeightId { get; set; }
        public ApplicationUser userId { get; set; }
        public DateTime time { get; set; }
        public int weight { get; set; }
        public int bodyFat { get; set; }
    }
}