using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase_Template
{
    internal class Visuals
    {

        public void View(string a, MovieCrud movieCrud)
        {
            if (a == "Movies")
            {

                var list = movieCrud.GetMovies();

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"\n{list[i].Id} ,{list[i].Title},  {list[i].Released}, {list[i].MainCharacter}, {list[i].Genre}, {list[i].IMDB}");
                }

            }
            else if (a == "Actors") 
            {
                var list = movieCrud.GetActors();
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"\n{list[i].ActorId}, {list[i].ActorName},{list[i].BornYear}");
                }

            }
        
        }
    }
}
