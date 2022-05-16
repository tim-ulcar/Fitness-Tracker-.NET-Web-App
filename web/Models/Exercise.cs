using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace web.Models
{
    public class Exercise
    {
        public int exerciseId { get; set; }
        public string exerciseName { get; set; }
        public string musclesWorked { get; set; }
    }
}