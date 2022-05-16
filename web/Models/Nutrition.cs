using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Nutrition
    {
        public int nutritionId { get; set; }
        public ApplicationUser userId { get; set; }
        public DateTime time { get; set; }
        public int calories { get; set; }
        public int protein { get; set; }
        public int carbohydrates { get; set; }
        public int fat { get; set; }
    }
}