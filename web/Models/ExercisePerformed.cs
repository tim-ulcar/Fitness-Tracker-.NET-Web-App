using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class ExercisePerformed
    {
        public int exercisePerformedId { get; set; }
        public ApplicationUser userId { get; set; }
        public string exerciseName { get; set; }
        public DateTime time { get; set; }
        public int weight { get; set; }
        public int sets { get; set; }
        public int reps { get; set; }
    }
}