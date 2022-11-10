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
Console.WriteLine("1 för add, 2 för delete");
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
}