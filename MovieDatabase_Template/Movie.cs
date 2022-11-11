namespace MovieDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class Movie
    {
        public int Id { get; set; } //auto incrament
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string IMDB { get; set; }
        public string MainCharacter { get; set; }
        public List<Actor> Actors { get; set; }
    }

        // Lägg till fler properties
    //}
}