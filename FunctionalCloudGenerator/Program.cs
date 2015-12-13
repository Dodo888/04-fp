using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using FunctionalCloudGenerator.ApplicationTypes;
using FunctionalCloudGenerator.CloudDrawers;
using FunctionalCloudGenerator.FileParsers;

namespace FunctionalCloudGenerator
{
    public static class Program
    {
        public static Dictionary<string, Func<string, Dictionary<string, int>>> TextTypes = 
            new Dictionary<string, Func<string, Dictionary<string, int>>>
        {
            {"dictionary", SimpleFileParser.GetWordsDictionaryFromFile}
        };

        public static Dictionary<string, Action<Bitmap, string, ImageFormat>> ApplicationTypes =
            new Dictionary<string, Action<Bitmap, string, ImageFormat>>
        {
            {"console", ConsoleApplication.CreateImage}
        };

        public static Dictionary<string, ImageFormat> Formats = 
            new Dictionary<string, ImageFormat>
        {
            {"png", ImageFormat.Png},
            {"jpeg", ImageFormat.Jpeg},
            {"bmp", ImageFormat.Bmp}
        };

        public static Dictionary<string, Func<Bitmap, Configuration, List<string>, Bitmap>> Algorithms = 
            new Dictionary<string, Func<Bitmap, Configuration, List<string>, Bitmap>>
        {
            {"simple", SimpleCloudDrawer.FormCloud},
            {"random", RandomCloudDrawer.FormCloud}
        };

        static void Main(string[] args)
        {
            var arguments = new CommandLineArgs(args);
            var config = new Configuration(arguments.ConfigFile);

            var wordsDictionary = TextTypes[config.TextType](arguments.TextFile);
            var bannedWordsDictionary = TextTypes[config.TextType](arguments.BannedWordsFile);
            var topWords = GetTopWords(wordsDictionary, bannedWordsDictionary, config.WordsAmount);

            var bitmap = new Bitmap(config.Width, config.Height);
            bitmap = Algorithms[config.Algorithm](bitmap, config, topWords);

            var resultPath = arguments.ResultFile + "." + config.ImageFormat;
            ApplicationTypes[config.ApplicationType](bitmap, resultPath, Formats[config.ImageFormat]);
        }

        public static List<string> GetTopWords(Dictionary<string, int> words, Dictionary<string, int> bannedWords, int amount)
        {
            return words
                .Where(item => !bannedWords.Keys.Contains(item.Key))
                .OrderByDescending(item => item.Value)
                .Take(amount)
                .Select(item => item.Key)
                .ToList();
        }
    }
}
