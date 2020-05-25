using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_LearningApp.Models
{
    public class Course
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Unesite naziv kursa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unesite link kursa")]
        public string Link { get; set; }
    }
}
