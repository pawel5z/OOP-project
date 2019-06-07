﻿using System;
using System.IO;

namespace Simple_games
{
    sealed class PhrasesContainer
    {
        private static PhrasesContainer instance;
        private readonly int count = 0;

        private PhrasesContainer()
        {
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

        public Phrase RandomPhrase
        {
            get
            {
                int phraseNr = App.rng.Next(0, count);
                int i = 0;
                string category = "";
                string phrase = "";
                try
                {
                    using (StreamReader sr = new StreamReader("assets\\phrases.dat"))
                    {
                        while (!sr.EndOfStream && i < phraseNr)
                        {
                            category = sr.ReadLine();
                            phrase = sr.ReadLine();
                            i++;
                        }
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
