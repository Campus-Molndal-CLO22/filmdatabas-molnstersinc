namespace MovieDatabase_Template
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MovieDatabase;
    using MySql.Data.MySqlClient;
    using Org.BouncyCastle.Asn1.Cms;

    public class MovieCrud
    {
        DataTable dt = new DataTable();//instansiera i moviecrud klass, så det kan användas i metoderna..
        MySqlDataAdapter adt = new MySqlDataAdapter(); //instansiera i moviecrud klass, så det kan användas i metoderna..
        string sql = ""; //skapa variabel

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

        public void AddActor(Actor actor, Movie movie)
        {
            // Kolla om skådespelaren finns i databasen
            // Uppdatera i så fall annars
            // Lägg till skådespelaren i databasen
            Console.WriteLine("Actors full name: ");
            var name = Console.ReadLine().ToUpper();
            if (actor.ActorName == name) {
                Console.WriteLine("This actor already exists");
            } 
            else if (actor.ActorName != name)
            {
            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd=LXDfTUg5SuRQSUrf;";

            var cnn = new MySqlConnection(connString);
            cnn.Open();
            Console.WriteLine($"Using Database: {cnn.Database}");
            var sql = "INSERT INTO Actor (ActorName, BornYear) VALUES (@ActorName, @BornYear)";
            var cmd = new MySqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@ActorName", name);

            Console.WriteLine("Actor is born year: ");
            cmd.Parameters.AddWithValue("@BornYear", Console.ReadLine());

            Console.WriteLine("the actor has been added...");
            cmd.ExecuteNonQuery();
                cnn.Close();
                //AddActorToMovie(actor, movie, name);
            }
        }

        public void AddActorToMovie(Actor actor, Movie movie, string name)
        {
            string movieId = "";
            Console.WriteLine("What is the name of the movie you want to add actor to?");
            string movieName = Console.ReadLine().ToUpper();
            var movies = GetMovies();
            int x = 0;
            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd=LXDfTUg5SuRQSUrf;";
            var cnn = new MySqlConnection(connString);
            cnn.Open();
            do
            {
                if (movies[x].Title.ToUpper() == movieName)
                {
                    movieId = movies[x].Id.ToString();
                    break;
                } else
                {
                    x++;
                }
            } while (true);
            // Kolla om relationen finns i databasen, i så fall är du klar
            var actors = GetActors();
            int i = 0;
                int y = 0;
            string act = actors[y].ActorName.ToUpper().ToString();
                for (y = 0; y < actors.Count; y++)
                {
                    if (act == name)
                    {
                        break;
                    }
                    else
                    {
                        act = actors[y].ActorName.ToUpper();
                    }
                }
            do {
                    if (act == name && movieId == movies[x].Id.ToString()) {
                Console.WriteLine("This actor is already in the movie");
                    i++;
                    break;
            }
            else{
                    
                i++;
                    }
            var sql = "INSERT INTO Cast (ActorId, MovieId) VALUES (@ActorId, @MovieId)";
            var cmd = new MySqlCommand(sql, cnn);
                    var actorId = actors[y-1].ActorId.ToString();
            cmd.Parameters.AddWithValue("@ActorId", actorId);
            cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                
            } while (true);
            // Annars lägg till relationen mellan filmen och skådespelaren i databasen
            // VAD GÖR VI NUUUU ?? :OOOOO

            // Kolla om skådisen redan finns
            // Lägg till skådisen i Actor.ActorName
            // "INSERT INTO Actor (ActorName) VALUES (@ActorName)"
            // Kolla om filmen finns
            // Länka Cast.MovieId med Actor.ActorId - Borde funka?

            // "INSERT INTO Cast (ActorId) VALUES (@ActorId)"


        }

        public List<Movie> GetMovies()
        {
            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd=LXDfTUg5SuRQSUrf;";
            var cnn = new MySqlConnection(connString);
            cnn.Open();
            List<Movie> movieList = new();
            dt = new DataTable();
            sql = "SELECT * "
            + "FROM Movies";//SQL kod, som skickas in (sen)
            adt = new MySqlDataAdapter(sql, cnn);//tar med parameter från sql koden och skickar till databasen. 
            adt.Fill(dt);//hämtar data från databasen som gör så att vi ska kunna se den. 

            int i = 0;
            foreach (DataRow row in dt.Rows) 
            {
                Movie movie = new Movie();
                movie.Id = int.Parse(row["MovieId"].ToString()); 
                movie.Title = row["Title"].ToString(); 
                movie.Released = row["Released"].ToString();
                movie.MainCharacter = row["MainCharacter"].ToString();
                movie.Genre = row["Genre"].ToString();
                movie.IMDB = row["IMDB"].ToString();
                movieList.Add(movie);
                i++;
            };
            return movieList;
            cnn.Close();

            // Hämta alla filmer från databasen
            // Hämta alla skådespelare från databasen
            // Hämta alla relationer mellan filmer och skådespelare från databasen
            // Skapa en lista med filmer
            // Lägg till skådespelarna till filmerna
            // Returnera listan med filmer
        }

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


       public List<Actor> GetActors()
        {
            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd=LXDfTUg5SuRQSUrf;";
            var cnn = new MySqlConnection(connString);
            cnn.Open();
            List<Actor> listOfActors = new();
            dt = new DataTable();

            sql = "SELECT * "
            + "FROM Actor";                                 //SQL kod, som skickas in (sen)
            adt = new MySqlDataAdapter(sql, cnn);           //tar med parameter från sql koden och skickar till databasen. 
            adt.Fill(dt);                                   //hämtar data från databasen som gör så att vi ska kunna se den. 
            
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                Actor actor = new Actor();
              
                actor.ActorId = int.Parse(row["ActorId"].ToString());
                actor.ActorName = row["ActorName"].ToString();
                actor.BornYear = int.Parse(row["BornYear"].ToString());
         
                listOfActors.Add(actor);
                i++;
            };
         
            return listOfActors;
            cnn.Close();


            // Hämta alla skådespelare från databasen
            // Hämta alla relationer mellan filmer och skådespelare från databasen
            // Hämta alla matchande filmer från databasen
            // Skapa en lista med skådespelare
            // Lägg till filmerna till skådespelarna
            // Returnera listan med skådespelare

        }

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
            string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=s60127_Eric;Pwd= LXDfTUg5SuRQSUrf;";
            var cnn = new MySqlConnection(connString);
            cnn.Open();
            Console.WriteLine($"Using Database: {cnn.Database}");
            var sql = "DELETE FROM Actor WHERE ActorName LIKE @Input";
            var cmd = new MySqlCommand(sql, cnn);
            Console.WriteLine("Vafan heter skådisen du vill ta bort?");
            var input = Console.ReadLine();
            cmd.Parameters.AddWithValue("@Input", input);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"The {input} has been deleted");
            cnn.Close();
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
