namespace BasicAI.Actions
{
    public static class NestedLevel
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

            Dictionary<string, Dictionary<string, string>> nestedKeywords = new Dictionary<string, Dictionary<string, string>>
            {
                { "book", new Dictionary<string, string>
                    {
                        { "describe", "Books is a brief overview of the plot, main characters, and themes of the story." },
                        { "recommend", "I recommend reading 'To Kill a Mockingbird' by Harper Lee." }
                    }
                }
            };

            Console.WriteLine(greetings[random.Next(greetings.Count)]);

            while (true)
            {
                Console.Write("Says something (or type 'bye' to quit): ");
                string user = Console.ReadLine().ToLower();

                if (user == "bye")
                {
                    Console.WriteLine(goodbyes[random.Next(goodbyes.Count)]);
                    break;
                }

                bool keywordFound = false;

                foreach (var keyword in keywords)
                {
                    if (user.Contains(keyword.Key))
                    {
                        // Check for nested keywords first
                        if (nestedKeywords.ContainsKey(keyword.Key))
                        {
                            foreach (var nestedKeyword in nestedKeywords[keyword.Key])
                            {
                                if (user.Contains(nestedKeyword.Key))
                                {
                                    Console.WriteLine("Bot: " + nestedKeyword.Value);
                                    keywordFound = true;
                                    break;
                                }
                            }
                        }

                        if (!keywordFound)
                        {
                            Console.WriteLine("Bot: " + keyword.Value);
                            keywordFound = true;
                        }

                        break;
                    }
                }

                if (!keywordFound)
                {
                    Console.Write("I'm not sure how to respond. What keyword should I respond to? ");
                    string newKeyword = Console.ReadLine().ToLower();
                    Console.Write("How should I respond to " + newKeyword + "? ");
                    string newResponse = Console.ReadLine();

                    if (newKeyword.Contains(" "))
                    {
                        var parts = newKeyword.Split(' ');
                        var primaryKey = parts[0];
                        var subKey = parts[1];

                        if (!nestedKeywords.ContainsKey(primaryKey))
                        {
                            nestedKeywords[primaryKey] = new Dictionary<string, string>();
                        }
                        nestedKeywords[primaryKey][subKey] = newResponse;
                    }
                    else
                    {
                        keywords[newKeyword] = newResponse;
                    }
                }
            }
        }
    }
}