using MovieDatabase;
using MovieDatabase_Template;

Console.WriteLine("Hello, Movie fans!");

// Börja med att lägga till Nuget för MySQL
// Sen kan ni kolla på koden ;)

// Uppgift:
// Skapa en eller flera tabeller som ska
// innehålla information om filmer och skådespelare
string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=[Insert Username];Pwd=[Insert Password];";

var movieCrud = new MovieCrud(connString);
var movie = new Movie();
var movieId = movie.Id;
var actor = new Actor();
var actorId = actor.Id;

Console.WriteLine("1 för add, 2 för delete, 3 för add actor, 4 to delete actor, 5 to view movie list");
switch (Console.ReadKey().Key)
{
    case ConsoleKey.D1:
    case ConsoleKey.NumPad1:
        movieCrud.AddMovie(movie);
        break;
    case ConsoleKey.D2:
    case ConsoleKey.NumPad2:
        movieCrud.DeleteMovie(movieId);
        break;
    case ConsoleKey.D3:
        movieCrud.AddActor(actor);
        break;
    case ConsoleKey.D4:
        movieCrud.DeleteActor(actorId);
        break;
    case ConsoleKey.D5:
        var movieList = movieCrud.GetMovies();
        for (int i = 0; i < movieList.Count; i++)
        {
            Console.WriteLine($"{movieList[i].Id} ,{movieList[i].Title},  {movieList[i].Released}, {movieList[i].MainCharacter}, {movieList[i].Genre}, {movieList[i].IMDB}");
        }
        break;
}