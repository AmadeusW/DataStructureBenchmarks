using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Deo.DataStructureBenchmarks
{
    public class WordTokenizer
    {
        private string File;
        private List<string> Words;

        [GlobalSetup]
        public void Setup()
        {
            Words = new List<string>();
            File = System.IO.File.ReadAllText(@"C:\src\DataStructureBenchmarks\Deo.DataStructureBenchmarks\Regex\sample.txt");
        }

        [Benchmark]
        public void StringTokenizer()
        {
            int i = 0;
            int wordStart = -1;
            while (i < File.Length)
            {
                char currentChar = File[i];
                if (currentChar >= 65 && currentChar <= 90)
                {
                    // Uppercase letter
                    if (wordStart != -1)
                    {
                        // A word just ended
                        var word = File.Substring(wordStart, i - wordStart);
                        if (word.Length > 1)
                        {
                            Words.Add(word);
                        }
                    }
                    // Begin a word
                    wordStart = i;
                }
                else if (currentChar >= 97 && currentChar <= 122)
                {
                    // Lowercase letter
                    if (wordStart == -1)
                    {
                        wordStart = i;
                    }
                }
                else
                {
                    if (wordStart != -1)
                    {
                        // A word just ended
                        var word = File.Substring(wordStart, i - wordStart);
                        wordStart = -1;
                        if (word.Length > 1)
                        {
                            Words.Add(word);
                        }
                    }
                }
                i++;
            }
            //Console.WriteLine($"StringTokenizer found {Words.Count} words.");
            //System.IO.File.WriteAllLines(@"E:\StringTokenizer.txt", Words);
        }

        [Benchmark]
        public void RegexTokenizer()
        {
            var wordRegex = new Regex(@"([A-Z][a-z]*)|\W([a-z]+)");
            var words = wordRegex.Matches(File);
            for (int i = 0; i < words.Count; i++)
            {
                var group1 = words[i].Groups[1].Value;
                var group2 = words[i].Groups[2].Value;
                var word = string.IsNullOrWhiteSpace(group1) ? group2 : group1;
                if (word.Length > 1)
                {
                    Words.Add(word);
                }
            }
            //Console.WriteLine($"RegexTokenizer found {Words.Count} words.");
            //System.IO.File.WriteAllLines(@"E:\RegexTokenizer.txt", Words);
        }

        [Benchmark]
        public void CompiledRegexTokenizer()
        {
            var wordRegex = new Regex(@"([A-Z][a-z]*)|\W([a-z]+)", RegexOptions.Compiled);
            var words = wordRegex.Matches(File);
            for (int i = 0; i < words.Count; i++)
            {
                var group1 = words[i].Groups[1].Value;
                var group2 = words[i].Groups[2].Value;
                var word = string.IsNullOrWhiteSpace(group1) ? group2 : group1;
                if (word.Length > 1)
                {
                    Words.Add(word);
                }
            }
            //Console.WriteLine($"CompiledRegexTokenizer found {Words.Count} words.");
            //System.IO.File.WriteAllLines(@"E:\CompiledRegexTokenizer.txt", Words);
        }
    }
}
