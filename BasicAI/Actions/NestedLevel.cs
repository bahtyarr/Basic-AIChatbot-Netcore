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
                Console.Write("Say something (or type 'bye' to quit): ");
                string user = Console.ReadLine().ToLower();

                if (user == "bye")
                {
                    Console.WriteLine(goodbyes[random.Next(goodbyes.Count)]);
                    break;
                }

                bool keywordFound = false;

                // Check for nested keywords first
                foreach (var mainKeyword in nestedKeywords)
                {
                    if (user.Contains(mainKeyword.Key))
                    {
                        foreach (var nestedKeyword in mainKeyword.Value)
                        {
                            if (user.Contains(nestedKeyword.Key))
                            {
                                Console.WriteLine("Bot: " + nestedKeyword.Value);
                                keywordFound = true;
                                break;
                            }
                        }
                        if (keywordFound) break;
                    }
                }

                // Check for main keywords if no nested keyword was found
                if (!keywordFound)
                {
                    foreach (var keyword in keywords)
                    {
                        if (user.Contains(keyword.Key))
                        {
                            Console.WriteLine("Bot: " + keyword.Value);
                            keywordFound = true;
                            break;
                        }
                    }
                }

                // Allow user to add new keywords and responses
                if (!keywordFound)
                {
                    Console.Write("I'm not sure how to respond. What main keyword should I respond to? ");
                    string mainKeyword = Console.ReadLine().ToLower();

                    // Check if the user wants to add a nested keyword
                    Console.Write("Would you like to add a nested keyword for " + mainKeyword + " (yes or no)? ");
                    string addNested = Console.ReadLine().ToLower();

                    if (addNested == "yes")
                    {
                        Console.Write("What nested keyword should I respond to under " + mainKeyword + "? ");
                        string nestedKeyword = Console.ReadLine().ToLower();

                        Console.Write("How should I respond to " + nestedKeyword + " under " + mainKeyword + "? ");
                        string newResponse = Console.ReadLine();

                        if (!nestedKeywords.ContainsKey(mainKeyword))
                        {
                            nestedKeywords[mainKeyword] = new Dictionary<string, string>();
                        }
                        nestedKeywords[mainKeyword][nestedKeyword] = newResponse;
                    }
                    else
                    {
                        Console.Write("How should I respond to " + mainKeyword + "? ");
                        string newResponse = Console.ReadLine();

                        keywords[mainKeyword] = newResponse;
                    }
                }
            }
        }
    }
}
