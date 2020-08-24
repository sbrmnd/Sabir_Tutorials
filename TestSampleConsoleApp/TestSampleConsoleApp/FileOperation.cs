using System;
using System.IO;
using System.Collections.Generic;

namespace TestSampleConsoleApp
{
    public class FileOperation
    {
        private string rootFolder = string.Empty;
        private string textFile = string.Empty;
        public FileOperation(string rFolder, string tFile)
        {
            rootFolder = rFolder;
            textFile = rFolder + tFile;
        }
        /// <summary>
        /// Read the file line by line
        /// </summary>
        /// <returns>array of string of lines</returns>
        private string[] ReadAFileLineByLine()
        {
            string[] lines = null;
            if (File.Exists(textFile))
            {
                lines = File.ReadAllLines(textFile);
            }
            return lines;
        }

        /// <summary>
        /// Read Entire Text In File Content In single String.
        /// </summary>
        /// <returns>string</returns>
        private string ReadEntireTextInFileContentIn1String()
        {
            string text = string.Empty;
            if (File.Exists(textFile))
            {  
                // Read entire text file content in one string    
                text = File.ReadAllText(textFile);
            }
            return text;

        }

        /// <summary>
        /// Read file using StreamReader. Reads file line by line 
        /// </summary>
        private void ReadStream()
        {
            if (File.Exists(textFile))
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    int counter = 0;
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                        counter++;
                    }
                    file.Close();
                }
            }
        }

        /// <summary>
        /// Count the occurance of words and put them in dictionary and update the word counts.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Dictionary</returns>
        private Dictionary<string, int> CountTheOccurenceOfTheWords(string[] lines)
        {
            Dictionary<string, int> wordsCollection = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                string[] words = line.Split(' ');

                foreach (var word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        if (wordsCollection.TryGetValue(word, out var val))
                        {
                            wordsCollection[word] = val + 1;
                        }
                        else
                        {
                            wordsCollection.Add(word, 1);
                        }
                    }
                }
            }
            return wordsCollection;
        }

        /// <summary>
        /// Display the Words count in a given text file.
        /// </summary>
        public void DisplayWordsCount()
        {
            Dictionary<string, int> wordsCollection = CountTheOccurenceOfTheWords(ReadAFileLineByLine());

            foreach (KeyValuePair<string, int> word in wordsCollection)
            {
                Console.WriteLine("{0} : {1} Times", word.Key, word.Value);
            }
        }
    }
}
