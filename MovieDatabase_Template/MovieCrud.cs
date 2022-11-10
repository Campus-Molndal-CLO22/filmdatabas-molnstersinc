namespace MovieDatabase_Template
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MovieDatabase;
    using MySql.Data.MySqlClient;

    public class MovieCrud
    {
        string connString = "";
        MySqlConnection cnn = null;

        public MovieCrud(string connString) { }

        public void AddMovie(Movie movie)
        {
            // Kolla om filmen redan finns, uppdatera i så fall
            // Om inte, lägg till filmen i databasen
            // Lägg till skådespelarna i databasen
            // Lägg till relationen mellan filmen och skådespelarna i databasen

            Console.WriteLine("Hello, MySQL!");

            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd=LXDfTUg5SuRQSUrf;";

            var cnn = new MySqlConnection(connString);
            cnn.Open();
            Console.WriteLine($"Using Database: {cnn.Database}");
            var sql = "INSERT INTO Movies (Title, Released, MainCharacter, Genre, IMDB) VALUES (@Title, @Released, @MainCharacter ,@Genre, @IMDB)";
            var cmd = new MySqlCommand(sql, cnn);

            Console.WriteLine("Add a title of the movie: ");
            cmd.Parameters.AddWithValue("@Title", Console.ReadLine());

            Console.WriteLine("Add the release date of the movie(Year): ");
            cmd.Parameters.AddWithValue("@Released", Console.ReadLine());

            Console.WriteLine("Add the main character of the movie: ");
            cmd.Parameters.AddWithValue("@MainCharacter", Console.ReadLine());

            Console.WriteLine("Add the genre of the movie: ");
            cmd.Parameters.AddWithValue("@Genre", Console.ReadLine());

            Console.WriteLine("Add the movie link to IMDB: ");
            cmd.Parameters.AddWithValue("@IMDB", Console.ReadLine());

            cmd.ExecuteNonQuery();
            Console.WriteLine($"The movie has been added");
            Console.ReadLine();
            cnn.Close();
        }

        public void AddActor(Actor actor)
        {
            // Kolla om skådespelaren finns i databasen
            // Uppdatera i så fall annars
            // Lägg till skådespelaren i databasen
        }

        public void AddActorToMovie(Actor actor, Movie movie)
        {
            // Kolla om relationen finns i databasen, i så fall är du klar
            // Annars lägg till relationen mellan filmen och skådespelaren i databasen
        }

        //public List<Movie> GetMovies()
        //{
        //    // Hämta alla filmer från databasen
        //    // Hämta alla skådespelare från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Skapa en lista med filmer
        //    // Lägg till skådespelarna till filmerna
        //    // Returnera listan med filmer
        //}

        //public List<Movie> GetMoviesContaining(string search)
        //{
        //    // Hämta alla matchande filmer från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla relaterade skådespelare från databasen
        //    // Skapa en lista med filmer
        //    // Lägg till skådespelarna till filmerna
        //    // Returnera listan med filmer
        //}

        //public List<Movie> GetMoviesFromYear(int year)
        //{
        //    // Hämta alla matchande filmer från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla relaterade skådespelare från databasen
        //    // Skapa en lista med filmer
        //    // Lägg till skådespelarna till filmerna
        //    // Returnera listan med filmer
        //}

        //public List<Movie> GetMovie(int Id)
        //{
        //    // Hämta matchande film från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla relaterade skådespelare från databasen
        //    // Skapa en lista med filmer
        //    // Lägg till skådespelarna till filmerna
        //    // Returnera listan med filmer
        //}

        //public List<Movie> GetMovie(string name)
        //{
        //    // Hämta matchande film från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla relaterade skådespelare från databasen
        //    // Skapa en lista med filmer
        //    // Lägg till skådespelarna till filmerna
        //    // Returnera listan med filmer
        //}


        //public List<Actor> GetActors()
        //{
        //    // Hämta alla skådespelare från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla matchande filmer från databasen
        //    // Skapa en lista med skådespelare
        //    // Lägg till filmerna till skådespelarna
        //    // Returnera listan med skådespelare
        //}

        //public List<Actor> GetActorsInMovie(Movie movie)
        //{
        //    // Hämta alla skådespelare från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla matchande filmer från databasen
        //    // Skapa en lista med skådespelare
        //    // Lägg till filmerna till skådespelarna
        //    // Returnera listan med skådespelare
        //}

        //public List<Movie> GetMoviesWithActor(Actor actor)
        //{
        //    // Hämta alla skådespelare från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla matchande filmer från databasen
        //    // Skapa en lista med skådespelare
        //    // Lägg till filmerna till skådespelarna
        //    // Returnera listan med skådespelare
        //}

        //public List<Movie> GetMoviesWithActor(string actorName)
        //{
        //    // Hämta alla skådespelare från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla matchande filmer från databasen
        //    // Skapa en lista med skådespelare
        //    // Lägg till filmerna till skådespelarna
        //    // Returnera listan med skådespelare
        //}

        //public List<Movie> GetMoviesWithActor(int actorId)
        //{
        //    // Hämta alla skådespelare från databasen
        //    // Hämta alla relationer mellan filmer och skådespelare från databasen
        //    // Hämta alla matchande filmer från databasen
        //    // Skapa en lista med skådespelare
        //    // Lägg till filmerna till skådespelarna
        //    // Returnera listan med skådespelare
        //}

        public void DeleteActor(int actorId)
        {
            // Ta bort skådespelaren från databasen
            // Ta bort alla relationer mellan skådespelaren och filmerna från databasen
        }

        public void DeleteMovie(int movieId)
        {
            // Ta bort filmen från databasen
            // Ta bort alla relationer mellan filmen och skådespelarna från databasen

            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd= LXDfTUg5SuRQSUrf;";

            var cnn = new MySqlConnection(connString);
            cnn.Open();
            Console.WriteLine($"Using Database: {cnn.Database}");
            var sql = "DELETE FROM Movies WHERE Title LIKE @Input";
            var cmd = new MySqlCommand(sql, cnn);
            Console.WriteLine("Vafan heter filmen du vill ta bort?");
            var input = Console.ReadLine();
            cmd.Parameters.AddWithValue("@Input", input);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"The {input} has been deleted");
            cnn.Close();
        }
    }
}
