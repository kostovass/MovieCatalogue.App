using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogue.Shared
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }




    }
}
