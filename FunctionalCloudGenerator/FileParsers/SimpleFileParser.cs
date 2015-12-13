using System.Collections.Generic;
using System.IO;

namespace FunctionalCloudGenerator.FileParsers
{
    public static class SimpleFileParser
    {
        public static Dictionary<string, int> GetWordsDictionaryFromFile(string path)
        {
            var wordsDictionary = new Dictionary<string, int>();
            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    line = line.ToLower();
                    if (wordsDictionary.ContainsKey(line))
                    {
                        wordsDictionary[line]++;
                    }
                    else
                    {
                        wordsDictionary.Add(line, 1);
                    }
                }
            }
            return wordsDictionary;
        }
    }
}
