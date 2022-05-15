using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogue.Shared
{
    public class Movie
    {
        public Movie()
        {
            List<Person> persons = new List<Person>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Rating { get; set; }
        [Display (Name ="Download URL")]
        public string DownloadURL { get; set; }
        [Display (Name ="The Image URL")]
        public string ImgURL { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<Movie> movies { get; set; }

        public static void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        [NotMapped]
        public byte[] ImageContent { get; set; }
        public string ImageName { get; set; }
    }
}
