using BUSINESSLOGICdb;
using MODELSdb;
using System;
using System.Collections.Generic;

namespace projectexample
{
    internal class Program
    {
        public static void DISPLAY(AnimeContent anime)
        {
            Console.WriteLine("TITLE: " + anime.title);
            Console.WriteLine("STUDIO: " + anime.studio);
            Console.WriteLine("RELEASE DATE: " + anime.releasedate);
            Console.WriteLine("STATUS: " + anime.status);
            Console.WriteLine("GENRE: " + anime.genre);
            Console.WriteLine("EPISODES: " + anime.episodes);
            Console.WriteLine("SUMMARY: " + anime.summary);
            Console.WriteLine("____________________________________________________");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("HELLO! WELCOME TO MY PROGRAM..." + "\n ");
            Console.WriteLine("BEFORE YOU CONTINUE, PLEASE ENTER YOUR USERNAME AND PASSWORD...");
            Console.WriteLine("\n____________________________________________________" + "\n");
            Console.Write("USERNAME: ");
            string username = Console.ReadLine();
            Console.Write("PASSWORD: ");
            string password = Console.ReadLine();

            AnimeProcess process = new AnimeProcess();
            VerifyingUser user = new VerifyingUser();
            // Assuming you have a method to verify users, omitted for brevity
            bool result = user.VerifysUser(username, password);

            if (result)
            {
                Console.WriteLine("\nLogin Successfully");
            }
            else
            {
                Console.WriteLine("\nError");
                Environment.Exit(0);
            }

            while (true)
            {
                Console.WriteLine("____________________________________________________");
                Console.WriteLine("PLEASE PICK WHAT DO YOU LIKE TO DO: " + "\n");
                Console.WriteLine("ONE - SEARCH AN ANIME IN THE EXISTING LIST");
                Console.WriteLine("TWO - LOOK AT THE WHOLE LIST");
                Console.WriteLine("THREE - ADD ANOTHER ANIME");
                Console.WriteLine("FOUR - REMOVE AN ANIME");
                Console.WriteLine("EXIT - ENDING PROGRAM");
                Console.WriteLine("\n____________________________________________________");
                Console.Write("YOUR CHOSEN NUMBER IS: ");
                string num = Console.ReadLine().ToUpper();
                Console.WriteLine("____________________________________________________");

                Console.Clear();

                if (num == "ONE")
                {
                    Console.Write("ENTER A KEYWORD TO SEARCH: ");
                    string keyword = Console.ReadLine();
                    List<AnimeContent> searchResults = process.SearchAnime(keyword);

                    if (searchResults.Count > 0)
                    {
                        foreach (var anime in searchResults)
                        {
                            DISPLAY(anime);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No results found.");
                    }

                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else if (num == "TWO")
                {
                    List<AnimeContent> animeContents = process.GetAllAnime();
                    foreach (var anime in animeContents)
                    {
                        DISPLAY(anime);
                    }

                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else if (num == "THREE")
                {
                    Console.WriteLine("ENTER THE DETAILS FOR THE NEW ANIME: ");
                    Console.Write("TITLE: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("STUDIO: ");
                    string newStudio = Console.ReadLine();
                    Console.Write("RELEASE DATE: ");
                    string newRD = Console.ReadLine();
                    Console.Write("STATUS: ");
                    string newStatus = Console.ReadLine();
                    Console.Write("GENRE: ");
                    string newGenre = Console.ReadLine();
                    Console.Write("EPISODES: ");
                    string newEpisodes = Console.ReadLine();
                    Console.Write("SUMMARY: ");
                    string newSummary = Console.ReadLine();

                    AnimeContent newAnime = new AnimeContent
                    {
                        title = newTitle,
                        studio = newStudio,
                        releasedate = newRD,
                        status = newStatus,
                        genre = newGenre,
                        episodes = newEpisodes,
                        summary = newSummary
                    };
                    process.AddAnime(newAnime);

                    Console.WriteLine("NEW ANIME HAS BEEN ADDED TO THE LIST");
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else if (num == "FOUR")
                {
                    Console.Write("ENTER THE TITLE OF THE ANIME TO REMOVE: ");
                    string removeTitle = Console.ReadLine();
                    int removed = process.RemoveAnime(removeTitle);

                    if (removed > 0)
                    {
                        Console.WriteLine($"{removeTitle} HAS BEEN REMOVED");
                    }
                    else
                    {
                        Console.WriteLine($"{removeTitle} DOES NOT EXIST");
                    }

                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                               
                  else if (num == "EXIT")
                {
                    Console.WriteLine("ENDING PROGRAM");
                    break;
                }
                else
                {
                    Console.WriteLine("INVALID OPTION");
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}
