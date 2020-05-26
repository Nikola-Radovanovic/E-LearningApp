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
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unesite link kursa")]
        [MaxLength(300)]
        public string Link { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
    }
}
