using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using RedditAccessor.models;

namespace RedditAccessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RedditWebRequest request = new RedditWebRequest();
            //request.Password = ReadPassword();

            request.Password = "";

            request.AccessToken = RedditRequestHandler.GetRedditAccessToken(request);
            RedditRequestHandler.GetSavedPosts(request);

        }

        static string ReadPassword()
        {
            string password = "";

            Console.Write("Enter your password: ");

            // Read individual characters without displaying them
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Ignore non-character keys like Enter or Backspace
                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Handle backspace by removing the last character from the password
                    password = password.Remove(password.Length - 1);
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return password;
        }
    }
}