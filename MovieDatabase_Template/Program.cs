using MovieDatabase;
using MovieDatabase_Template;
Visuals visuals = new();
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
var actorId = actor.ActorId;
while (true)
{
    Console.WriteLine("1 för add, 2 för delete, 3 för add actor, 4 to delete actor, 5 to view movie list, 6 view actors");
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
            movieCrud.AddActor(actor, movie);
            break;
        case ConsoleKey.D4:
            movieCrud.DeleteActor(actorId);
            break;
        case ConsoleKey.D5:
            visuals.View("Movies", movieCrud);
            break;
        case ConsoleKey.D6:
            visuals.View("Actors", movieCrud);
            break;
        case ConsoleKey.Escape:
            Environment.Exit(0);
            break;
    }
}