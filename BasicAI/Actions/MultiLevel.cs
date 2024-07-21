namespace BasicAI.Actions
{
    public static class MultiLevel
    {
        public static void Run()
        {
            Random random = new Random();
            List<string> greetings = new List<string> { "Hello!", "What's up?", "Howdy!", "Greetings!" };
            List<string> goodbyes = new List<string> { "Bye!", "Goodbye!", "See you later!", "See you soon!" };

            // Primary keywords and their general responses
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

            // Nested keywords and their detailed responses
            Dictionary<string, Dictionary<string, string>> nestedKeywords = new Dictionary<string, Dictionary<string, string>>
            {
                { "book", new Dictionary<string, string>
                    {
                        { "describe", "Books is a brief overview of the plot, main characters, and themes of the story." },
                        { "recommend", "I recommend reading 'To Kill a Mockingbird' by Harper Lee." }
                    }
                },
                { "technology", new Dictionary<string, string>
                    {
                        { "latest", "The latest technology includes AI advancements and quantum computing." },
                        { "impact", "Technology impacts almost every aspect of modern life, from communication to transportation." }
                    }
                }
            };

            // Multi-level nested keywords and their responses
            Dictionary<string, Dictionary<string, Dictionary<string, string>>> multiLevelNestedKeywords = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
            {
                { "book", new Dictionary<string, Dictionary<string, string>>
                    {
                        { "describe", new Dictionary<string, string>
                            {
                                { "genres", "Books can be of many genres like fiction, non-fiction, mystery, and fantasy." },
                                { "benefits", "Books provide an escape to different worlds and ideas." }
                            }
                        },
                        { "recommend", new Dictionary<string, string>
                            {
                                { "classic", "I recommend reading 'Pride and Prejudice' by Jane Austen." },
                                { "modern", "I recommend reading 'The Road' by Cormac McCarthy." }
                            }
                        }
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

                // Check for multi-level nested keywords first
                foreach (var primaryKeyword in multiLevelNestedKeywords)
                {
                    if (user.Contains(primaryKeyword.Key))
                    {
                        foreach (var nestedKeyword in primaryKeyword.Value)
                        {
                            if (user.Contains(nestedKeyword.Key))
                            {
                                foreach (var subKeyword in nestedKeyword.Value)
                                {
                                    if (user.Contains(subKeyword.Key))
                                    {
                                        Console.WriteLine("Bot: " + subKeyword.Value);
                                        keywordFound = true;
                                        break;
                                    }
                                }
                                if (keywordFound) break;
                            }
                        }
                        if (keywordFound) break;
                    }
                }

                // Check for single-level nested keywords
                if (!keywordFound)
                {
                    foreach (var keyword in keywords)
                    {
                        if (user.Contains(keyword.Key))
                        {
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
                                    else
                                    {
                                        Console.WriteLine("Bot: " + keyword.Value);
                                        keywordFound = true;
                                        break;
                                    }
                                }
                                if (keywordFound) break;
                            }
                            else
                            {
                                Console.WriteLine("Bot: " + keyword.Value);
                                keywordFound = true;
                                break;
                            }
                        }
                    }
                }

                // Allow user to add new keywords and responses
                if (!keywordFound)
                {
                    Console.Write("I'm not sure how to respond. What keyword should I respond to? ");
                    string newKeyword = Console.ReadLine().ToLower();

                    if (newKeyword.Contains(" "))
                    {
                        var parts = newKeyword.Split(' ', 2);
                        var parentKeyword = parts[0];
                        var subKeyword = parts[1];

                        Console.Write("How should I respond to " + subKeyword + " under " + parentKeyword + "? ");
                        string newResponse = Console.ReadLine();

                        if (!multiLevelNestedKeywords.ContainsKey(parentKeyword))
                        {
                            multiLevelNestedKeywords[parentKeyword] = new Dictionary<string, Dictionary<string, string>>();
                        }

                        if (!multiLevelNestedKeywords[parentKeyword].ContainsKey(subKeyword))
                        {
                            multiLevelNestedKeywords[parentKeyword][subKeyword] = new Dictionary<string, string>();
                        }

                        // Assuming sub-keywords are further categorized
                        Console.Write("Specify the level of sub-keyword (e.g., 'genres', 'benefits'): ");
                        string levelKeyword = Console.ReadLine().ToLower();

                        multiLevelNestedKeywords[parentKeyword][subKeyword][levelKeyword] = newResponse;
                    }
                    else
                    {
                        Console.Write("How should I respond to " + newKeyword + "? ");
                        string newResponse = Console.ReadLine();
                        keywords[newKeyword] = newResponse;
                    }
                }
            }
        }
    }
}