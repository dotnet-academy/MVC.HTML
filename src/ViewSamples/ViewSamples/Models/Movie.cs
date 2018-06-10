using System;

namespace ViewSamples.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public Movie()
        {
            Id = Guid.NewGuid();
        }
    }
}
