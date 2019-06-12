using System;
using System.IO;

namespace Simple_games
{
    /// <summary>
    /// This is lazy container i.e. it doesn't contain all phrases in one of its fields.
    /// Instead of that, it calculates number of available phrases upon construction and then,
    /// when asked for random phrase, it uses App's static @rng to generate random number between
    /// 0 and @count and reads from assets\phrases.dat till that number.
    /// </summary>
    sealed class PhrasesContainer
    {
        private static PhrasesContainer instance;
        private readonly int count = 0;

        /// <summary>
        /// Standard read-from-file method taken from https://docs.microsoft.com/pl-pl/dotnet/standard/io/how-to-read-text-from-a-file.
        /// Calculates number of phrases stored in assets\phrases.dat file.
        /// </summary>
        private PhrasesContainer()
        {
            count = 0;
            try
            {
                using (StreamReader sr = new StreamReader("assets\\phrases.dat"))
                {
                    while (!sr.EndOfStream)
                    {
                        string category = sr.ReadLine();
                        string phrase = sr.ReadLine();
                        count++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static PhrasesContainer Instance()
        {
            if (instance == null)
                instance = new PhrasesContainer();
            return instance;
        }

        /// <summary>
        /// Read to (@count - 1) phrase and return that phrase i.e. category and content strings.
        /// </summary>
        public Phrase RandomPhrase
        {
            get
            {
                int phraseNr = App.rng.Next(count);
                int i = 0;
                string category = "";
                string phrase = "";
                try
                {
                    using (StreamReader sr = new StreamReader("assets\\phrases.dat"))
                    {
                        do
                        {
                            category = sr.ReadLine();
                            phrase = sr.ReadLine();
                            i++;
                        }
                        while (!sr.EndOfStream && i < phraseNr);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
                return new Phrase(phrase, category);
            }
        }
    }


}
