using System;
using System.Collections.Generic;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }

            //Console.ReadKey();

        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            char[] strarray = new char[word.Length + 1];
            Dictionary<char, int> lcCharSet = new Dictionary<char, int>();

            strarray = word.ToCharArray();
            foreach (char item in strarray)
            {
                if (!lcCharSet.ContainsKey(item))
                {
                    lcCharSet.Add(item, 1);
                }
                else
                {
                    lcCharSet[item] = lcCharSet[item] + 1;
                }

            }

            foreach (var item in lcCharSet)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }

            //Console.ReadKey();
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return false;
            if (a.Length != b.Length)
                return false;

            foreach (char c in b)
            {
                int ix = a.IndexOf(c);
                if (ix >= 0)
                    a = a.Remove(ix, 1);
                else
                    return false;
            }

            return string.IsNullOrEmpty(a);
        }
    }
}
