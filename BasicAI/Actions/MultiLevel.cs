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
                }

                // Allow user to add new keywords and responses
                if (!keywordFound)
                {
                    Console.Write("I'm not sure how to respond. What main keyword should I respond to? ");
                    string mainKeyword = Console.ReadLine().ToLower();

                    Console.Write("Would you like to add a nested keyword for " + mainKeyword + " (yes or no)? ");
                    string addNested = Console.ReadLine().ToLower();

                    if (addNested == "yes")
                    {
                        Console.Write("What nested keyword should I respond to under " + mainKeyword + "? ");
                        string nestedKeyword = Console.ReadLine().ToLower();

                        Console.Write("Would you like to add an additional keyword for " + nestedKeyword + " under " + mainKeyword + "? (yes or no)? ");
                        string addMultiLevel = Console.ReadLine().ToLower();

                        if (addMultiLevel == "yes")
                        {
                            Console.Write("What additional keyword should I respond to under " + nestedKeyword + " under " + mainKeyword + "? ");
                            string multiLevelKeyword = Console.ReadLine().ToLower();

                            Console.Write("How should I respond to " + multiLevelKeyword + " under " + nestedKeyword + " under " + mainKeyword + "? ");
                            string multiLevelResponse = Console.ReadLine();

                            if (!multiLevelNestedKeywords.ContainsKey(mainKeyword))
                            {
                                multiLevelNestedKeywords[mainKeyword] = new Dictionary<string, Dictionary<string, string>>();
                            }

                            if (!multiLevelNestedKeywords[mainKeyword].ContainsKey(nestedKeyword))
                            {
                                multiLevelNestedKeywords[mainKeyword][nestedKeyword] = new Dictionary<string, string>();
                            }

                            multiLevelNestedKeywords[mainKeyword][nestedKeyword][multiLevelKeyword] = multiLevelResponse;
                        }
                        else
                        {
                            Console.Write("How should I respond to " + nestedKeyword + " under " + mainKeyword + "? ");
                            string nestedResponse = Console.ReadLine();

                            if (!nestedKeywords.ContainsKey(mainKeyword))
                            {
                                nestedKeywords[mainKeyword] = new Dictionary<string, string>();
                            }
                            nestedKeywords[mainKeyword][nestedKeyword] = nestedResponse;
                        }
                    }
                    else
                    {
                        Console.Write("How should I respond to " + mainKeyword + "? ");
                        string mainResponse = Console.ReadLine();
                        keywords[mainKeyword] = mainResponse;
                    }
                }
            }
        }
    }
}
