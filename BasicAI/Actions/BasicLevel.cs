namespace BasicAI.Actions
{
    public static class BasicLevel
    {
        public static void Run()
        {
            Random random = new Random();
            List<string> greetings = new List<string> { "Hello!", "What's up?", "Howdy!", "Greetings!" };
            List<string> goodbyes = new List<string> { "Bye!", "Goodbye!", "See you later!", "See you soon!" };

            Dictionary<string, string> keywords = new Dictionary<string, string>
            {
                { "music", "Music is so relaxing!" },
                { "pet", "Dogs are man's best friend!" },
                { "book", "I know about a lot of books." },
                { "game", "I like to play video games." },
                { "food", "Food is essential and delicious!" },
                { "weather", "The weather can be quite unpredictable." },
                { "movie", "Movies are a great way to escape reality." },
                { "travel", "Traveling opens up new perspectives." },
                { "sport", "Sports are great for physical fitness." },
                { "technology", "Technology is constantly evolving." }
            };

            Console.WriteLine(greetings[random.Next(greetings.Count)]);

            while (true)
            {
                Console.Write("Say something (or type 'bye' to quit): ");
                string user = Console.ReadLine().ToLower();

                if (user == "bye")
                {
                    Console.WriteLine(goodbyes[random.Next(goodbyes.Count)]);
                    break;
                }

                bool keywordFound = false;

                foreach (var kvp in keywords)
                {
                    if (user.Contains(kvp.Key))
                    {
                        Console.WriteLine("Bot: " + kvp.Value);
                        keywordFound = true;
                        break;
                    }
                }

                if (!keywordFound)
                {
                    Console.Write("I'm not sure how to respond. What keyword should I respond to? ");
                    string newKeyword = Console.ReadLine().ToLower();

                    Console.Write("How should I respond to " + newKeyword + "? ");
                    string newResponse = Console.ReadLine();

                    keywords[newKeyword] = newResponse;
                }
            }
        }
    }
}
